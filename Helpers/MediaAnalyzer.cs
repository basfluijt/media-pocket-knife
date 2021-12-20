namespace MediaSorter.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class MediaAnalyzer
    {
        public static List<MediaItem> GatherMediaInformation(List<string> SourceFiles)
        {
            var resultList = new List<MediaItem>();
            
            foreach (var file in SourceFiles)
            {
                var fileInfo = new FileInfo(file);
                var fileTagLib = TagLib.File.Create(file);
                var test = TagLib.
                resultList.Add(new MediaItem()
                {
                    Date = fileTags ?? fileInfo.LastWriteTimeUtc,
                    Extension = fileInfo.Extension,
                    Directory = fileInfo.Directory,
                    Path = file,
                    Size = fileInfo.Length,
                    FileName = fileInfo.Name,
                    FullFileName = fileInfo.FullName
                });
            }

            return resultList;
        }
    }
}