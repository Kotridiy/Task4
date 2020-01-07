using FileWatcherData;
using FileWatcherData.Interfaces;
using FileWatcherModel;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class FileLogic
    {
        IWatcherUnitOfWork WatcherUnitOfWork { get; set; }

        public FileLogic()
        {
            WatcherUnitOfWork = WatcherBuilder.CreateUnitOfWork();
        }

        public void OnFileCreate(object sender, FileSystemEventArgs e)
        {
            FileInfo info = new FileInfo(e.FullPath);
            Guid fileID = new Guid(FileHash.GetFileHash(info));

            var file = WatcherUnitOfWork.GetFile(fileID);
            if (file == null || file.Status == FileStatus.Failed)
            {
                if (file == null)
                {
                    file = new WatchFile
                    {
                        Id = fileID,
                        Name = info.Name,
                        LastWriteTime = info.LastWriteTime,
                        Length = info.Length,
                    };
                }
                file.Status = FileStatus.OnReading;
                WatcherUnitOfWork.AddFile(file);

                Task<IFile> readingTask = new Task<IFile>(() => ReadFile(file));
                Task afterReadTask = readingTask.ContinueWith(task => AfterReading(task.Result));
                readingTask.Start();
            }
        }

        private void AfterReading(IFile file)
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

        private IFile ReadFile(IFile file)
        {
            if ((new Random()).Next() % 2 == 0)
            {
                file.Status = FileStatus.Success;
            } else
            {
                file.Status = FileStatus.Failed;
            }
            return file;
        }
    }
}
