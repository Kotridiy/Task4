using FileWatcherModel;
using System;

namespace FileWatcherData.Interfaces
{
    public interface IWatcherUnitOfWork
    {
        IFile GetFile(Guid guid);
        void AddFile(IFile file);
        void ModifyStatus(Guid guid, FileStatus status);
    }
}
