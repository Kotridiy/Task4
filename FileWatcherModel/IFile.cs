using System;

namespace FileWatcherModel
{
    public interface IFile
    {
        Guid Id { get; }
        string Name { get; }
        long Length { get; }
        DateTime LastWriteTime { get; }
        FileStatus Status { get; set; }
    }
}
