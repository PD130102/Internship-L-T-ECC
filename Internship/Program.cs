using System.Data.SqlClient;
using Internship.Models;
using Internship.Services;
internal class Program
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
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
        
        connectionstring = "Server=(localdb)\\MSSQLLocalDB;Database=SampleDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        SqlConnection connection;
        SqlCommand cmd1, cmd2, cmd3, cmd4,cmd5,cmd6,cmd7;
        string? sql1, sql2, sql3, sql4,sql5,sql6,sql7,sql8,sql9;
        SqlDataReader dr1, dr2, dr3, dr4,dr5,dr6,dr7;
        SqlDataReader dataReader1,dataReader2; 
        SqlCommand command1, command2;
        try
        {
            connection = new SqlConnection(connectionstring);
            connection.Open();
            for (int i = 1; i < 3; i++)
            {
                sql8 = "SELECT company_code,company_name,completed_latitudes,completed_longitudes FROM MapData_cmpl WHERE company_code =" + i + ";";
                sql9 = "SELECT company_code,company_name,inprogress_latitudes,inprogress_longitudes FROM MapData_inpr WHERE company_code=" + i + ";";
                command1 = new SqlCommand(sql8, connection);
                command2 = new SqlCommand(sql9, connection);
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                dataReader1 = command1.ExecuteReader();
                dataReader2 = command2.ExecuteReader();
                MapData mapData = new MapData();
                List<Single> cmpl_lat_1 = new List<Single>();
                List<Single> cmpl_long_1 = new List<Single>();
                while (dataReader1.Read())
                {
                    mapData.company_code = dataReader1.GetInt32(0);
                    mapData.company_name = dataReader1.GetString(1);
                    cmpl_lat_1.Add(dataReader1.GetFloat(2));
                    cmpl_long_1.Add(dataReader1.GetFloat(3));
                }
                mapData.completed_latitudes = cmpl_lat_1;
                mapData.completed_longitudes = cmpl_long_1;
                dataReader1.Close();
                command1.Dispose();
                List<Single> inpr_lat_1 = new List<Single>();
                List<Single> inpr_long_1 = new List<Single>();
                while (dataReader2.Read())
                {
                    inpr_lat_1.Add(dataReader2.GetFloat(2));
                    inpr_long_1.Add(dataReader2.GetFloat(3));
                }
                mapData.inprogress_latitudes = inpr_lat_1;
                mapData.inprogress_longitudes = inpr_long_1;
                dataReader2.Close();
                command2.Dispose();

                MapDataService.Add(mapData);
            }
            for (int x = 1; x < 3; x++)
            {
                sql1 = "Select companyName from Company where companyCode =" + x + ";";
                sql2 = "Select sectorID,sectorName,sectorDescription FROM Sector where companyCode=" + x + ";";

                CompanyAPI companyAPI = new CompanyAPI();
                
                cmd1 = new SqlCommand(sql1, connection);
                dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    companyAPI.CompanyCode = x;
                    companyAPI.CompanyName = dr1.GetString(0);
                }
                dr1.Close();
                cmd1?.Dispose();
                

                cmd2 = new SqlCommand(sql2, connection);
                dr2 = cmd2.ExecuteReader();
                List<Sector> listsectors = new List<Sector>();
                while(dr2.Read())
                {
                    
                        Sector sector = new Sector();
                        sector.SectorID = dr2.GetInt32(0);
                        sector.SectorName = dr2.GetString(1);
                        sector.SectorDescription = dr2.GetString(2);
                        /*  sql3 = "Select materialName from Materials where SectorID= " + y +";";
                          sql4 = "Select skillName from Skills where SectorID= " + y +  ";";
                          sql5 = "Select projectName from Projects where SectorID= " + y +  ";";
                          sql6 = "Select factorName from Factors where SectorID= " + y +  ";";
                          sql7 = "Select attributeName from Attributes where SectorID= " + y + ";";*/

                        sql3 = "Select materialName from Materials,Company where Materials.SectorID= " + sector.SectorID + " and Company.companyCode=" + x + ";";
                        sql4 = "Select skillName from Skills,Company where Skills.SectorID= " + sector.SectorID + " and Company.companyCode=" + x + ";";
                        sql5 = "Select projectName from Projects,Company where Projects.SectorID= " + sector.SectorID + " and Company.companyCode=" + x + ";";
                        sql6 = "Select factorName from Factors,Company where Factors.SectorID= " + sector.SectorID + " and Company.companyCode=" + x + ";";
                        sql7 = "Select attributeName from Attributes,Company where Attributes.SectorID= " + sector.SectorID + " and Company.companyCode=" + x + ";";
                        // Materials
                        cmd3 = new SqlCommand(sql3, connection);
                        dr3 = cmd3.ExecuteReader();
                        List<string> materials = new List<string>();
                        while (dr3.Read())
                        {
                            materials.Add(dr3.GetString(0));
                        }
                        sector.Materials = materials;
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
                        sector.Skills = skills;
                        dr4.Close();
                        cmd4.Dispose();

                        // Projects
                        cmd5 = new SqlCommand(sql5, connection);
                        dr5 = cmd5.ExecuteReader();
                        List<string> projects  = new List<string>();
                        while(dr5.Read())
                        {
                            projects.Add(dr5.GetString(0));
                        }
                        sector.Projects = projects;
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
                        sector.Factors = factors;
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
                        sector.Atributes = attributes;
                        dr7.Close();
                        cmd7.Dispose();
                        listsectors.Add(sector);
                    
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