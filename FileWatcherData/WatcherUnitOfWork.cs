using System;
using FileWatcherData.Interfaces;
using FileWatcherModel;

namespace FileWatcherData
{
    class WatcherUnitOfWork : IWatcherUnitOfWork
    {
        internal IFileWatcherRepository Repository { get; private set; }

        public WatcherUnitOfWork(IFileWatcherRepository repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IFile GetFile(Guid guid)
        {
            return Repository.Get(guid);
        }

        public void AddFile(IFile file)
        {
            if (file.Id == null)
            {
                throw new Exception("Guid can't be null. Use hash for it.");
            }
            Repository.Add(file);
            Repository.Save();
        }

        public void ModifyStatus(Guid guid, FileStatus status)
        {
            IFile file = Repository.Get(guid);
            if (file != null) 
            {
                file.Status = status;
                Repository.Save();
            } 
            else
            {
                throw new Exception("File not found.");
            }
        }
    }
}
