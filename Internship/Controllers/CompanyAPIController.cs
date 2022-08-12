using Microsoft.AspNetCore.Mvc;
using Internship.Models;
using Internship.Services;
namespace Internship.Controllers;

[ApiController]
[Route("[controller]")]

public class CompanyAPIController : ControllerBase
{
    public CompanyAPIController()
    {
    }
    [HttpGet]
    public ActionResult<List<CompanyAPI>> GetAll() => CompanyAPIService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<CompanyAPI> Get(int id) => CompanyAPIService.Get(id);
}
   
