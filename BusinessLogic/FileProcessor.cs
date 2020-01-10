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

                var file = WatcherUnitOfWork.GetFile(fileID);
                if (file == null || file.Status == FileStatus.Failed || true)
                {
                    if (file == null)
                    {
                        file = new FileDTO
                        {
                            Id = fileID,
                            Name = info.Name,
                            LastWriteTime = info.LastWriteTime,
                            Length = info.Length,
                        };
                    }
                    file.Status = FileStatus.OnReading;
                    WatcherUnitOfWork.AddFile(file);

                    Task<FileDTO> readingTask = new Task<FileDTO>(() => ReadFile(file, info.FullName, managerName));
                    Task afterReadTask = readingTask.ContinueWith(task => AfterReading(task.Result));
                    readingTask.Start();
                }
            }
        }

        private void AfterReading(FileDTO file)
        {
            WatcherUnitOfWork.ModifyStatus(file.Id, file.Status);
            if (file.Status == FileStatus.Success)
            {
                Console.WriteLine(file.Name + " read");
            }
            else
            {
                Console.WriteLine(file.Name + " cancel");
            }
        }

        private FileDTO ReadFile(FileDTO file, string fullpath, string managerName)
        {
            if (CsvParser.ReadCsvFile(fullpath, managerName))
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