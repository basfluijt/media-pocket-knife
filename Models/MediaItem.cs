﻿namespace MediaSorter
{
    using System;
    using System.IO;

    public class MediaItem
    {
        public string Path { get; set; }
        public DirectoryInfo Directory { get; set; }
        public string FileName { get; set; }
        public string FullFileName { get; set; }
        public string Extension { get; set; }
        public string Location { get; set; }
        public long Size { get; set; }
        public DateTime Date { get; set; }
        public bool IsDuplicate { get; set; }
        public bool IsProcessed { get; set; }
        public string MoveLocation { get; set; }
    }
}