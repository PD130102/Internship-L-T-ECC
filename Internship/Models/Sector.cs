namespace Internship.Models
{
    public class Sector
    {
        public int SectorID { get; set; }
        public string? SectorName { get; set; }
        public string? SectorDescription { get; set; }
        public List<string>? Skills { get; set; }
        public List<string>? Projects { get; set; }
        public List<string>? Factors { get; set; }
        public List<string>? Atributes { get; set; }
        public List<string>? Materials { get; set; }
    }
}
