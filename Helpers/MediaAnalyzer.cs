namespace MediaSorter.Helpers
{
    using System.Collections.Generic;
    using System.IO;
    using File = TagLib.File;

    public static class MediaAnalyzer
    {
        public static List<MediaItem> GatherMediaInformation(List<string> SourceFiles)
        {
            var resultList = new List<MediaItem>();

            foreach (var file in SourceFiles)
            {
                var fileInfo = new FileInfo(file);
                var fileTagLib = File.Create(file);
                // TODO: Find a way to determine actual media shot date instead of the regular creation/updated date for that date is wrong 9 out of 10 times.

                resultList.Add(new MediaItem
                {
                    Date = fileTagLib.Tag.DateTagged ?? fileInfo.LastWriteTimeUtc,
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