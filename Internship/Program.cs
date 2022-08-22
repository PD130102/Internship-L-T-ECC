using System.Data.SqlClient;
using Internship.Models;
using Internship.Services;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        string? connectionstring = null;
        connectionstring = "Server=localhost;Database=SampleDB;Trusted_Connection=True;MultipleActiveResultSets=true;";
        SqlConnection connection;
        SqlCommand cmd1, cmd2, cmd3, cmd4,cmd5,cmd6,cmd7;
        string? sql1, sql2, sql3, sql4,sql5,sql6,sql7;
        SqlDataReader dr1, dr2, dr3, dr4,dr5,dr6,dr7;
        try
        {
            connection = new SqlConnection(connectionstring);
            connection.Open();
            for (int x = 1; x < 3; x++)
            {
                sql1 = "Select companyCode,companyName from Company where companyCode =" + x + ";";
                sql2 = "Select sectorID,sectorName,sectorDescription FROM Sector where companyCode=" + x + ";";

                CompanyAPI companyAPI = new CompanyAPI();
                
                cmd1 = new SqlCommand(sql1, connection);
                dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    companyAPI.CompanyCode = dr1.GetInt32(0);
                    companyAPI.CompanyName = dr1.GetString(1);
                }
                dr1.Close();
                cmd1.Dispose();
                

                cmd2 = new SqlCommand(sql2, connection);
                dr2 = cmd2.ExecuteReader();
                List<Sector> listsectors = new();
                while (dr2.Read())
                {
                    
                        Sector sector = new()
                        {
                            SectorID = dr2.GetInt32(0),
                            SectorName = dr2.GetString(1),
                            SectorDescription = dr2.GetString(2)
                        };

                        sql3 = "Select materialName from Materials where SectorID= " + sector.SectorID + " and CompanyCode = " + x + "; ";
                        sql4 = "Select skillName from Skills where SectorID= " + sector.SectorID + " and CompanyCode = " + x + ";";
                        sql5 = "Select projectName from Projects where SectorID= " + sector.SectorID + " and CompanyCode = " + x + ";";
                        sql6 = "Select factorName from Factors where SectorID= " + sector.SectorID + " and CompanyCode = " + x + ";";
                        sql7 = "Select attributeName from Attributes where SectorID= " + sector.SectorID + " and CompanyCode = " + x + ";";

                       /* sql3 = "Select materialName from Materials,Company,Sector where Materials.SectorID= " + y + "and Materials.SectorID = Sector.sectorID and  Materials.CompanyCode = Company.companyCode and Company.companyCode=" + x + ";";
                        sql4 = "Select skillName from Skills,Company,Sector where Skills.SectorID= " + y + "and Skills.SectorID = Sector.sectorID and Skills.CompanyCode = Company.companyCode and Company.companyCode=" + x + ";";
                        sql5 = "Select projectName from Projects,Company,Sector where Projects.SectorID= " + y + "and Projects.SectorID = Sector.sectorID and  Projects.CompanyCode = Company.companyCode and Company.companyCode=" + x + ";";
                        sql6 = "Select factorName from Factors,Company,Sector where Factors.SectorID= " + y + "and Factors.SectorID = Sector.sectorID and Factors.CompanyCode = Company.companyCode and Company.companyCode=" + x + ";";
                        sql7 = "Select attributeName from Attributes,Company,Sector where Attributes.SectorID= " + y + "and Attributes.SectorID = Sector.sectorID and Attributes.CompanyCode = Company.companyCode and Company.companyCode=" + x + ";";*/

                        // Materials
                        cmd3 = new SqlCommand(sql3, connection);
                        dr3 = cmd3.ExecuteReader();
                        List<string> materials = new List<string>();
                        while (dr3.Read())
                        {
                            materials.Add(dr3.GetString(0));
                        }
                        if (materials.Count > 0)
                        {
                            sector.Materials = materials;
                        }
                        dr3.Close();
                        cmd3.Dispose();

                        // Skills
                        cmd4 = new SqlCommand(sql4, connection);
                        dr4 = cmd4.ExecuteReader();
                        List<string> skills = new List<string>();
                        while (dr4.Read())
                        {
                            skills.Add(dr4.GetString(0));
                        }
                        if (skills.Count > 0)
                        {
                            sector.Skills = skills;
                        }
                        dr4.Close();
                        cmd4.Dispose();

                        // Projects
                        cmd5 = new SqlCommand(sql5, connection);
                        dr5 = cmd5.ExecuteReader();
                        List<string> projects = new List<string>();
                        while (dr5.Read())
                        {
                            projects.Add(dr5.GetString(0));
                        }
                        if (projects.Count > 0)
                        {
                            sector.Projects = projects;
                        }
                        dr5.Close();
                        cmd5.Dispose();

                        // Factors
                        cmd6 = new SqlCommand(sql6, connection);
                        dr6 = cmd6.ExecuteReader();
                        List<string> factors = new List<string>();
                        while (dr6.Read())
                        {
                            factors.Add(dr6.GetString(0));
                        }
                        if(factors.Count > 0)
                        {
                            sector.Factors = factors;
                        }
                        dr6.Close();
                        cmd6.Dispose();

                        // Attributes
                        cmd7 = new SqlCommand(sql7, connection);
                        dr7 = cmd7.ExecuteReader();
                        List<string> attributes = new List<string>();
                        while (dr7.Read())
                        {
                            attributes.Add(dr7.GetString(0));
                        }
                        if(attributes.Count > 0)
                        {
                            sector.Atributes = attributes;
                        }
                        dr7.Close();
                        cmd7.Dispose();

                        if(sector.Projects !=null && sector.Atributes != null && sector.Factors != null && sector.Materials != null && sector.Skills != null)
                        {
                            listsectors.Add(sector);
                        }
                        else
                        {
                            continue;
                        }
                    
                }
                dr2.Close();
                cmd2.Dispose();
                companyAPI.Sectors = listsectors;
                CompanyAPIService.Add(companyAPI);
            }
            connection.Close();
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}