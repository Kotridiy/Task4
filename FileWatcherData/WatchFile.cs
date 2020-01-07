using FileWatcherModel;
using System;

namespace FileWatcherData
{
    public class WatchFile : IFile
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public long Length { get; set; }

        public DateTime LastWriteTime { get; set; }

        public FileStatus Status { get; set; }
    }
}
