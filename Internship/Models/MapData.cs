namespace Internship.Models;

public class MapData
{
    public int company_code { get; set; }
    public  string? company_name { get; set; }
    public List<Single>? inprogress_longitudes { get; set; }
    public  List<Single>? inprogress_latitudes { get; set; }
    public  List<Single>? completed_longitudes { get; set; }
    public  List<Single>? completed_latitudes  { get; set; }

}

