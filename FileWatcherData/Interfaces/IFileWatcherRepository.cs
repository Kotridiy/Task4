using FileWatcherModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileWatcherData.Interfaces
{
    interface IFileWatcherRepository
    {
        IFile Get(Guid guid);
        void Add(IFile file);
        void Save();
    }
}
