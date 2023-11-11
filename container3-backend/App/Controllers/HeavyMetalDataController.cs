using Microsoft.AspNetCore.Mvc;
using System.Configuration;

using openComputingLab.Models;
using openComputingLab.Data;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Npgsql;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace openComputingLab.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HeavyMetalDataController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public HeavyMetalDataController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [ActionName("GetUnfilteredData")]
    public IActionResult GetData(string stupac = "", string parameter = "*")
    {
        System.FormattableString sql_query = $@"""select sng.name as ""song_name"" 
			,bnd.band_name as ""band name""
        	,bnd.members as ""band members""
        	,bnd.genre as ""genre""
        	,alb.name as ""album name""
        	,alb.label as ""album label""
        	,alb.date_released as ""album release date""
        	,sng.length as ""song length""
        	,sng.no_on_album as ""position on album""
        	,sng.lyrics_writers as ""lyrics writers""
        	,sng.music_writers as ""music writers""
        	,sng.lyrics as ""lyrics""
        from ""Band"" as bnd
        	join ""Album"" as alb on bnd.ident = alb.band_ident
        	join ""Song"" as sng on alb.ident = sng.album_ident
		where {stupac} like {parameter}
		order by asc;""";

		SongsData sequenceQueryResult = null;
		try{
        sequenceQueryResult = _dbContext.Database.SqlQuery<SongsData>(sql_query).FirstOrDefault();
		Console.WriteLine(sequenceQueryResult);
		}
		catch{
			Console.WriteLine("Database returned nothing.");
		}

        return Ok(sequenceQueryResult);
    }
}