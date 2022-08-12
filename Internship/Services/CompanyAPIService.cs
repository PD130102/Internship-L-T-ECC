using Internship.Models;



namespace Internship.Services
{
    public static class CompanyAPIService
    {
        static List<CompanyAPI> Companies { get; }
        static CompanyAPIService()
        {

            Companies = new List<CompanyAPI>()
            {
                new CompanyAPI
                {
                    CompanyCode = 1,
                    CompanyName = "L&T Construction",
                    Sectors = new List<Sector> ()
                    {
                        new Sector
                        {
                            SectorID = 1,
                            SectorName = "Airport",
                            SectorDescription = "Airport are Huge and Beautiful",
                            Skills = new List<string> { "architect", "engineer", "construction crew", "manager" },
                            Projects = new List<string>{"Delhi International Airport – T3","Hyderabad International Airport","Kannur International Airport","Salalah International Airport", "Oman","Abu Dhabi International Airport Complex"},
                            Factors = new List<string>{"Good","Time"},
                            Atributes = new List<string>{"Hello","World"},
                            Materials = new List<string>{ "iron", "carbon", "sand", "concrete" }
                        },
                        new Sector
                        {
                            SectorID = 2,
                            SectorName = "Bridge",
                            SectorDescription = "Bridges are Huge and Beautiful",
                            Skills = new List<string> { "architect", "engineer", "construction crew", "manager" },
                            Projects = new List<string>{"Delhi International Airport – T3","Hyderabad International Airport","Kannur International Airport","Salalah International Airport", "Oman","Abu Dhabi International Airport Complex"},
                            Atributes = new List<string>{"Hello","World"},
                            Factors = new List<string>{"Good","Time"},
                            Materials = new List<string>{ "iron", "carbon" }
                        }
                    }
                },
                new CompanyAPI
                {
                    CompanyCode = 2, 
                    CompanyName = "L&T InfoTech"
                }

            };
        }

        public static List<CompanyAPI> GetAll()
        {
            return Companies;
        }

        public static CompanyAPI Get(int id)
        {
            CompanyAPI? p = Companies.Find(p => p.CompanyCode == id);
            return p ?? throw new Exception("Companies not Found");
        }

        public static void Add(CompanyAPI company)
        {
            Companies.Add(company);
        }
     }
}
