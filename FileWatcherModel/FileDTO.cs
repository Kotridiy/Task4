using System;

namespace FileWatcherModel
{
    public class FileDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Length { get; set; }
        public DateTime LastWriteTime { get; set; }
        public FileStatus Status { get; set; }

        public string FullPath { get; set; }
    }
}
