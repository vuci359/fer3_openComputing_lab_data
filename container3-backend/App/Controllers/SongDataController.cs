using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Net.Http;
using openComputingLab.Data;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Npgsql;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.Unicode;
using System.Text;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Cors;
using openComputingLab.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

//using Newtonsoft.Json;

namespace openComputingLab.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")]
[EnableCors]

public class SongDataController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public SongDataController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [ActionName("GetData")]
    public IActionResult GetData(int ? stupac = null, string ? parameter = null){

		try{
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Song, Band?>? SongData = _dbContext.Songs.Include(s => s.Album).ThenInclude(a => a.Band);
                        
            if(parameter != null){
                switch(stupac){
                    case 0://song nam
                        SongData.Where(a => a.name.Contains(parameter));
                        break;
                    case 1://band name
                        SongData.Where(a => a.Album.Band.band_name.Contains(parameter));
                        break;
                    case 2://band members
                        SongData.Where(a => a.Album.Band.members.Contains(parameter));
                        break;
                    case 3://genre
                        SongData.Where(a => a.Album.Band.genre.Contains(parameter));
                        break;
                    case 4://album name
                        SongData.Where(a => a.Album.name.Contains(parameter));
                        break;
                    case 5://album label
                        SongData.Where(a => a.Album.label.Contains(parameter));
                        break;
                    case 6://album release date
                        SongData.Where(a => a.Album.date_released.Equals(parameter));
                        break;
                    case 7://song length
                        SongData.Where(a => a.length.Equals(parameter));
                        break;
                    case 8://position on album
                        SongData.Where(a => a.name.Contains(parameter));
                        break;
                    case 9://lyrics writers
                        SongData.Where(a => a.lyrics_writers.Contains(parameter));
                        break;
                    case 10://music writers
                        SongData.Where(a => a.music_writers.Contains(parameter));
                        break;
                    case 11://lyrics
                        SongData.Where(a => a.lyrics.Contains(parameter));
                        break;
                    default:
                        SongData.Where(a => a.name.Contains(parameter)||
                                //    a.length.Equals(parameter)||
                                //    a.no_on_album.Equals(number)||
                                    a.lyrics_writers.Contains(parameter)||
                                    a.music_writers.Contains(parameter)||
                                    a.lyrics.Contains(parameter)||
                                    a.Album.name.Contains(parameter)||
                                    a.Album.label.Contains(parameter)||
                                //    a.Album.date_released.Equals(parameter)||
                                    a.Album.Band.band_name.Contains(parameter)||
                                    a.Album.Band.members.Contains(parameter)||
                                    a.Album.Band.genre.Contains(parameter)
                                    );
                        break;
                    
                }
            }
            string json_string = JsonConvert.SerializeObject(SongData.ToList());
            return Ok(JsonValue.Parse("{\"podaci\":"+json_string+"}"));

        }catch(Exception e){
            Console.WriteLine(e.StackTrace);
        }

        return Ok();
    }
}

//		where {stupac} like {parameter}