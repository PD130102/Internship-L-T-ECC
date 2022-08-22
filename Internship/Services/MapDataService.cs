using Internship.Models;

namespace Internship.Services;
using System.Collections.Generic;

public static class MapDataService
{
    static List<MapData> mapData { get; }

    static MapDataService()
    {
        mapData = new List<MapData> { };
    }
    public static List<MapData> GetAll()
    {
        return mapData;
    }

    public static MapData Get(int id)
    {
        MapData? p = mapData.Find(p => p.company_code == id);
        return p ?? throw new Exception("MapData not found");
    }

    public static void Add(MapData mapdata)
    {
        mapData.Add(mapdata);
    }

}