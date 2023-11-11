using Microsoft.AspNetCore.Mvc;
using System.Configuration;

using openComputingLab.Models;
using openComputingLab.Data;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Npgsql;
using System.Data;

namespace openComputingLab.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HeavyMetalDataController: ControllerBase{
    private readonly AppDbContext _dbContext;

    public HeavyMetalDataController(AppDbContext dbContext){
        _dbContext = dbContext;
    }
    [HttpGet]
    [ActionName("GetUnfilteredData")]
    public IActionResult GetData(string stupac = "", string parameter = "*"){
        string sql_query_select = @"select sng.name as ""song_name""
			, nd.band_name as ""band name""
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
		join ""Song"" as sng on alb.ident = sng.album_ident";
		string sql_query_sort = " order by sng.name asc;";
		string sql_query_filter = "";
		if (stupac != "") sql_query_filter = " where"+stupac+"like"+parameter+" ";

		string sql_query = sql_query_select+sql_query_filter+sql_query_sort;
		Console.WriteLine(sql_query);

		NpgsqlConnection conn = new NpgsqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Ef_Postgres_Db"].ConnectionString);
		NpgsqlCommand command = new NpgsqlCommand(sql_query_filter, conn);
		NpgsqlDataReader reader = command.ExecuteReader();
		SongsData data = (SongsData)reader.Cast<SongsData>();
		Console.WriteLine(data.ToString());
        return Ok();
    }
}