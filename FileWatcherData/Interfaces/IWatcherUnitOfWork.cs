using FileWatcherModel;
using System;

namespace FileWatcherData.Interfaces
{
    public interface IWatcherUnitOfWork
    {
        FileDTO GetFile(Guid guid);
        void AddFile(FileDTO file);
        void ModifyStatus(Guid guid, FileStatus status);
    }
}
