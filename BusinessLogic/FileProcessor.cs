using BusinessLogic.Csv;
using DataAccessLayer.Interfaces;
using FileWatcherData;
using FileWatcherData.Interfaces;
using FileWatcherModel;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class FileProcessor
    {
        const string VALIDATEREGEX = @"^(\w+)_\d{8}(?:\((\d+)\))?\.csv$";
        readonly string readyPath;
        IWatcherUnitOfWork WatcherUnitOfWork { get; set; }
        IDataUnitOfWork DataUnitOfWork { get; set; }
        CsvParser CsvParser { get; set; }

        public FileProcessor(FileLogicSettings settings = null)
        {
            settings ??= new FileLogicSettings();
            readyPath = settings.readyPath;
            try
            {
                Directory.CreateDirectory(readyPath);
            }
            catch (Exception)
            {
                Console.WriteLine("Directory create exception!");
                throw;
            }
            WatcherUnitOfWork = WatcherBuilder.CreateUnitOfWork(settings.watcherConnection);
            DataUnitOfWork = DataAccessBuilder.CreateUnitOfWork(settings.dataConnection);
            CsvParser = new CsvParser(DataUnitOfWork);
        }

        public void OnFileCreate(object sender, FileSystemEventArgs e)
        {
            FileInfo info = new FileInfo(e.FullPath);
            Guid fileID = new Guid(FileHash.GetFileHash(info));

            Match match;
            match = Regex.Match(info.Name, VALIDATEREGEX);
            if (match.Success)
            {
                var managerName = match.Groups[1].Value;
                int copyNum = 0;
                if (match.Groups[2].Success)
                {
                    copyNum = int.Parse(match.Groups[2].Value);
                }

                FileDTO file = GetFile(fileID);
                if (file == null || file.Status == FileStatus.Failed)
                {
                    if (file == null)
                    {
                        file = new FileDTO
                        {
                            Id = fileID,
                            Name = info.Name,
                            LastWriteTime = info.LastWriteTime,
                            Length = info.Length,
                            FullPath = info.FullName
                        };
                    }
                    file.Status = FileStatus.OnReading;
                    SaveFile(file);

                    Task<FileDTO> readingTask = new Task<FileDTO>(() => ReadFile(file, managerName));
                    Task afterReadTask = readingTask.ContinueWith(task => AfterReading(task.Result));
                    readingTask.Start();
                }
            }
        }

        private void SaveFile(FileDTO file)
        {
            try
            {
                WatcherUnitOfWork.AddFileAndSave(file);
            }
            catch (Exception)
            {
                Console.WriteLine("Can't add file to database");
            }
        }

        private FileDTO GetFile(Guid fileID)
        {
            FileDTO file;
            try
            {
                file = WatcherUnitOfWork.GetFile(fileID);
            }
            catch (Exception)
            {
                Console.WriteLine("Can't get file in database");
                file = null;
            }

            return file;
        }

        private void AfterReading(FileDTO file)
        {
            WatcherUnitOfWork.ModifyStatusAndSave(file.Id, file.Status);
            if (file.Status == FileStatus.Success)
            {
                Console.WriteLine(file.Name + " read");
                File.Move(file.FullPath, readyPath + file.Name);
            }
            else
            {
                Console.WriteLine(file.Name + " cancel");
            }
        }

        private FileDTO ReadFile(FileDTO file, string managerName)
        {
            if (CsvParser.ReadCsvFile(file.FullPath, managerName))
            {
                file.Status = FileStatus.Success;
            }
            else
            {
                file.Status = FileStatus.Failed;
            }

            return file;
        }
    }
}