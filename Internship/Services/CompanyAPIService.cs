using Internship.Models;
using System.Collections.Generic;


namespace Internship.Services
{
    public static class CompanyAPIService
    {
        static List<CompanyAPI> companies { get; }
        static CompanyAPIService()
        {
            companies = new List<CompanyAPI> { };
            {
                new CompanyAPI
                {
                    CompanyName = "L&T Construction",
                    CompanyCode = 1,
                    Sectors = new List<Sector>
                    {
                        new Sector
                        {
                            SectorID = 1,
                            SectorName = "Airport",
                            SectorDescription = "Airport are Huge and Beautiful",
                            Skills = new List<string> { "architect", "engineer", "construction crew", "manager" },
                            Projects = new List<string>{"Delhi International Airport – T3","Hyderabad International Airport","Kannur International Airport","Salalah International Airport", "Oman","Abu Dhabi International Airport Complex"},
                            Atributes = new List<string>{"Hello","World"},
                            Factors = new List<string>{"Good","Time"},
                            Materials = new List<string>{ "iron", "carbon", "sand", "concrete" }
                        },
                        new  Sector
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

                };
                new CompanyAPI
                {
                    CompanyName = "L&T Infotech",
                    CompanyCode = 2,
                    Sectors = new List<Sector>
                    {
                        new Sector
                        {
                            SectorID = 1,
                            SectorName = "Airport",
                            SectorDescription = "Airport are Huge and Beautiful",
                            Skills = new List<string> { "architect", "engineer", "construction crew", "manager" },
                            Projects = new List<string>{"Delhi International Airport – T3","Hyderabad International Airport","Kannur International Airport","Salalah International Airport", "Oman","Abu Dhabi International Airport Complex"},
                            Atributes = new List<string>{"Hello","World"},
                            Factors = new List<string>{"Good","Time"},
                            Materials = new List<string>{ "iron", "carbon", "sand", "concrete" }
                        },
                        new  Sector
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

                };
            }
        }

        public static List<CompanyAPI> GetAll()
        {
            return companies;
        }

        public static CompanyAPI Get(int id)
        {
            CompanyAPI? p = companies.Find(p => p.CompanyCode == id);
            return p ?? throw new Exception("Companies not Found");
        }

        public static void Add(CompanyAPI company)
        {
            companies.Add(company);
        }
    }
}
