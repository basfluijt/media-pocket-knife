namespace MediaSorter.Models;

public class GeoCodeLocationCacheModel
{
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string FormattedAddress { get; set; }
}