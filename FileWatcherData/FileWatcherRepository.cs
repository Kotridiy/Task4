using FileWatcherData.Interfaces;
using FileWatcherModel;
using System;

namespace FileWatcherData
{
    class FileWatcherRepository : IFileWatcherRepository
    {
        internal FileWatcherContext FileWatcherContext { get; private set; }

        public FileWatcherRepository(FileWatcherContext fileWatcherContext)
        {
            FileWatcherContext = fileWatcherContext ?? throw new ArgumentNullException(nameof(fileWatcherContext));
        }

        public IFile Get(Guid guid)
        {
            return FileWatcherContext.Files.Find(guid);
        }

        public void Save()
        {
            FileWatcherContext.SaveChanges();
        }

        public void Add(IFile file)
        {
            FileWatcherContext.Add(file);
        }
    }
}
