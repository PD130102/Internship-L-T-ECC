namespace Internship.Models
{
    public class CompanyAPI
    {
        public int CompanyCode { get; set; }
        public string? CompanyName { get; set; }
        public List<Sector>? Sectors { get; set; }
    }
}