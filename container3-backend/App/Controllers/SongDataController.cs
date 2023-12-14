using Microsoft.AspNetCore.Mvc;
using openComputingLab.Data;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Cors;
using openComputingLab.Models;
using Microsoft.EntityFrameworkCore;

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
    public IActionResult GetData(){
        try{
            return Ok(_dbContext.Songs.Include(s => s.Album).ThenInclude(a => a.Band));

        }catch(Exception e){
           // Console.WriteLine(e.StackTrace);
            return NotFound();
        }

        return Ok();
    }

    [HttpGet]
    [ActionName("GetDataById")]
    public IActionResult GetDataById(int ident){
        try{
            return Ok(_dbContext.Songs.Where(a => a.ident.Equals(ident)).Include(s => s.Album).ThenInclude(a => a.Band));

        }catch(Exception e){
           // Console.WriteLine(e.StackTrace);
            return NotFound();
        }

        return Ok();
    }

    [HttpGet]
    [ActionName("GetStructuredData")]
    public IActionResult GetStructuredData(int ? stupac = null, string ? parameter = null){
        try{
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Song, Band?>? SongData;
            var song_filter = PredicateBuilder.False<Song>();
            int start = 0;
            int kraj=11;
            if(stupac != null){
                start = stupac.Value;
                kraj = stupac.Value;
            }
            
            if(parameter != null){
                for(int i=start; i<=kraj; i++){
                    switch(i){
                        case 0://song name
                            song_filter = song_filter.Or(a => a.name.Contains(parameter));
                            break;
                        case 1://band name
                            song_filter = song_filter.Or(a => a.Album.Band.band_name.Contains(parameter));
                            break;
                        case 2://band members
                            song_filter = song_filter.Or(a => a.Album.Band.members.Contains(parameter));
                            break;
                        case 3://genre
                            song_filter = song_filter.Or(a => a.Album.Band.genre.Contains(parameter));
                            break;
                        case 4://album name
                            song_filter = song_filter.Or(a => a.Album.name.Contains(parameter));
                            break;
                        case 5://album label
                            song_filter = song_filter.Or(a => a.Album.label.Contains(parameter));
                            break;
                        case 6://album release date
                            if (DateOnly.TryParse(parameter, out DateOnly dateValue)){
                                song_filter = song_filter.Or(a => a.Album.date_released.Equals(dateValue));
                            }
                            break;
                        case 7://song length
                            if (TimeSpan.TryParse(parameter, out TimeSpan timeValue)){
                                song_filter = song_filter.Or(a => a.length.Equals(timeValue));
                            }
                            break;
                        case 8://position on album
                            if (Int32.TryParse(parameter, out int numValue)){
                                song_filter = song_filter.Or(a => a.no_on_album.Equals(numValue));
                            }
                            break;
                        case 9://lyrics writers
                            song_filter = song_filter.Or(a => a.lyrics_writers.Contains(parameter));
                            break;
                        case 10://music writers
                            song_filter = song_filter.Or(a => a.music_writers.Contains(parameter));
                            break;
                        case 11://lyrics
                            song_filter = song_filter.Or(a => a.lyrics.Contains(parameter));
                            break;
                        default:                        
                            break;                   
                        }                    
                    }
                    SongData = _dbContext.Songs.Where(song_filter).Include(s => s.Album).ThenInclude(a => a.Band);
                }else{
                    SongData = _dbContext.Songs.Include(s => s.Album).ThenInclude(a => a.Band);

                }

            var resolver = new IgnorePropertiesResolver();

            resolver.ignoreProperty("Bandident");
            resolver.ignoreProperty("ident");
            resolver.ignoreProperty("Albumident");

            string json_string = JsonConvert.SerializeObject(SongData.ToList(), new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    ContractResolver = resolver

                });

            return Ok(JsonValue.Parse("{\"podaci\":"+json_string+"}"));

        }catch(Exception e){
           // Console.WriteLine(e.StackTrace);
            return NotFound();
        }

        return Ok();
    }
}

//		where {stupac} like {parameter}