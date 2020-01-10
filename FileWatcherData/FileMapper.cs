using FileWatcherModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileWatcherData
{
    public static class FileMapper
    {
        public static FileDTO ToFileDTO(WatchFile file)
        {
            return file == null ? null : new FileDTO()
            {
                Id = file.Id,
                Name = file.Name,
                Length = file.Length,
                LastWriteTime = file.LastWriteTime,
                Status = file.Status
            };
        }
        
        public static WatchFile ToFile(FileDTO file)
        {
            return file == null ? null : new WatchFile()
            {
                Id = file.Id,
                Name = file.Name,
                Length = file.Length,
                LastWriteTime = file.LastWriteTime,
                Status = file.Status
            };
        }
    }
}
