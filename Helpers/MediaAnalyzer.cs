namespace MediaSorter.Helpers
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.WindowsAPICodePack.Shell;
    // using File = TagLib.File;

    public static class MediaAnalyzer
    {
        internal static event SetProgressBarValues InitProgressBar;
        internal static event UpdateProgressBar ProcessProgressBar;

        public static List<MediaItem> GatherMediaInformation(List<string> SourceFiles)
        {
            var resultList = new List<MediaItem>();
            OnInitProgressBar(1, SourceFiles.Count, 1, $@"READING DATA FOR {SourceFiles.Count} MEDIA ITEMS", 1);

            foreach (var file in SourceFiles)
            {
                var fileInfo = new FileInfo(file);
                // var fileTagLib = File.Create(file); // Unused, but reserved for whenever we need more media specifics
                var fileCodepack = ShellObject.FromParsingName(file); // Used to get the real DateTime when media was shot (image/video)

                var mediaType = FileHelper.GetMediaType(file);
                var creationDate = fileCodepack?.Properties?.System?.ItemDate?.Value;
                var sourceName = fileCodepack?.Properties?.System?.ApplicationName?.Value;

                resultList.Add(new MediaItem
                {
                    Date = creationDate ?? fileInfo.LastWriteTimeUtc,
                    Extension = fileInfo.Extension,
                    Directory = fileInfo.Directory,
                    Path = file,
                    Size = fileInfo.Length,
                    FileName = fileInfo.Name,
                    FullFileName = fileInfo.FullName,
                    MediaType = mediaType,
                    Source = sourceName
                });

                OnProcessProgressBar();
            }

            return resultList;
        }

        private static void OnInitProgressBar(int minValue, int maxValue, int stepSize, string labelText, int bgColor)
        {
            InitProgressBar?.Invoke(minValue, maxValue, stepSize, labelText, bgColor);
        }

        private static void OnProcessProgressBar()
        {
            ProcessProgressBar?.Invoke();
        }

        internal delegate void SetProgressBarValues(int minValue, int maxValue, int stepSize, string labelText, int bgColor);

        internal delegate void UpdateProgressBar();
    }
}