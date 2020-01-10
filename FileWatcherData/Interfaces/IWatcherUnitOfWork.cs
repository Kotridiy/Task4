using FileWatcherModel;
using System;

namespace FileWatcherData.Interfaces
{
    public interface IWatcherUnitOfWork
    {
        FileDTO GetFile(Guid guid);
        void AddFileAndSave(FileDTO file);
        void ModifyStatusAndSave(Guid guid, FileStatus status);
    }
}
