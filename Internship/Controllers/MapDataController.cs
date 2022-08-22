using Internship.Models;
using  Internship.Services;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Controllers;

[ApiController]
[Route("[controller]")]

public class MapDataController : ControllerBase
{
    public MapDataController()
    {
    }

    [HttpGet]
    public ActionResult<List<MapData>> GetAll() => MapDataService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<MapData> Get(int id)
    {
        var mapData = MapDataService.Get(id);

        if (mapData == null)
            return NotFound();

        return mapData;
    }

}