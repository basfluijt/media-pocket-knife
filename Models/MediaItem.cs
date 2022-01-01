namespace MediaSorter
{
    using System;
    using System.Drawing;
    using System.IO;
    using Helpers;

    public class MediaItem
    {
        public string Path { get; set; }
        public DirectoryInfo Directory { get; set; }
        public string FileName { get; set; }
        public string FullFileName { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public DateTime Date { get; set; }
        public bool IsDuplicate { get; set; }
        public bool IsProcessed { get; set; }
        public string MoveLocation { get; set; }
        public string Source { get; set; }
        public Size ImageSize { get; set; }
        public FileHelper.MediaType MediaType { get; set; }
        public Orientation ImageOrientation { get; set; }
   }
    
    public enum Orientation 
    {
        Horizontal,
        Vertical
    }
}