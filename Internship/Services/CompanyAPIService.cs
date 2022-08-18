using Internship.Models;
using System.Collections.Generic;

namespace Internship.Services
{
    public static class CompanyAPIService
    {
        static List<CompanyAPI> Companies { get; }
        static CompanyAPIService()
        {

            Companies = new List<CompanyAPI> { };
           
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
