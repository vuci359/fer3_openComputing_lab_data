using Microsoft.AspNetCore.Mvc;
using System.Configuration;

using openComputingLab.Models;
using openComputingLab.Data;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Npgsql;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net.Sockets;

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
    public IActionResult GetData(string stupac = "*", string parameter = "*"){

		IDictionary<string, string> stupci = new Dictionary<string, string>
        {
            { "*", "*" },
			{ "song name", "sng.name" },
            { "band name", "bnd.band_name" },
            { "band members", "bnd.members" },
            { "genre", "bnd.genre" },
            { "album name", "alb.name" },
            { "album label", "alb.label" },
            { "album release date", "alb.date_released" },
            { "song length", "sng.length" },
            { "position on album", "sng.no_on_album" },
            { "lyrics writers", "sng.lyrics_writers" },
            { "music writers", "sng.music_writers" },
            { "lyrics", "sng.lyrics" }
        };

        string sql_select_clause = @"select array_to_json(array_agg(row_to_json(music_data))) from(
		select sng.name as ""song name""
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
		";

		string sql_where_clause = "";
		if(stupac.Equals("*")){
			sql_where_clause = "";
		}/*else if(stupac.Equals("album release date")){
			sql_where_clause = @"where "+stupci[stupac]+ " like '"+parameter;
		}*/else if(stupac.Equals("song length") || stupac.Equals("position on album")){
			sql_where_clause = @"where "+stupci[stupac]+ " like "+parameter;
		}/*else if(stupac.Equals("band members") || stupac.Equals("lyrics writers") || stupac.Equals("music writers")){
			sql_where_clause = @"where lower("+parameter+") in (select (UNNEST("+stupci[stupac]+")) where)";
		}*/else if(stupac.Equals("band members") || stupac.Equals("lyrics writers") || stupac.Equals("music writers")){
			sql_where_clause = @"where '"+parameter+ "' = ANY("+stupci[stupac]+")";
		}else{
			sql_where_clause = @"where LOWER("+stupci[stupac]+ ") like LOWER('%"+parameter+"%')";
		}
		
		
		string sql_order_clause = @" order by sng.name asc
		) music_data;";

		string sql_query = sql_select_clause+sql_where_clause+sql_order_clause;

		try{
			// Connect to a PostgreSQL database
          NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Database=opencomputing_lab_data;Port=5432;User Id=postgres;Password=fpD5gXw&B;Integrated Security=true;Pooling=true;");
          conn.Open();
 
          // Define a query returning a single row result set
          NpgsqlCommand command = new NpgsqlCommand(sql_query, conn);
 
          // Execute the query and obtain the value of the first column of the first row
          NpgsqlDataReader dr = command.ExecuteReader();
		string ? output = "";
         // Output rows
         while (dr.Read())
		 	if(dr[0] is System.DBNull){
				output = "";
			}else {
				output = (string)dr[0];
			}
			
			Console.WriteLine("sss");
         
		 conn.Close();
		 return Ok(output);

			//Console.WriteLine(output);
		}
		catch(Exception e){
			Console.WriteLine(e.Message);
			Console.WriteLine(sql_query);
		}

        return Ok();
    }
}

//		where {stupac} like {parameter}