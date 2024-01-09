using Microsoft.AspNetCore.Mvc;
using openComputingLab.Data;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Cors;
using openComputingLab.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Sources;

//using Newtonsoft.Json;

namespace openComputingLab.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[EnableCors]

public class SongController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public SongController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [ActionName("GetData")]
    public IActionResult GetData(){
        try{
            return Ok(_dbContext.Songs.ToArray());
        }catch(Exception e){
            return NotFound(new {Message = "No songs found!"});
        }
    }

    [HttpGet("{id}")]
    [ActionName("GetDataById")]
    public IActionResult GetDataById(int ? id = null){
        try{
            var song = _dbContext.Songs.Find(id);
            if (song == null) {
                throw new KeyNotFoundException("Song not found!");
            }
            return Ok(song);
        }catch(Exception e){
            return NotFound(new {Message = "Song NOT found!"});
        }
    }

    [HttpPost]
    [ActionName("PostData")]
    public IActionResult PostData([FromBody] Song song ){
        try{
            var songExist = _dbContext.Songs.Any(e => e.ident == song.ident);
            if (songExist == true){
                return Ok(new { Message = "Song already created!" });                    
            }
            _dbContext.Add(song);
            _dbContext.SaveChanges();
            return Ok(new { Message = "Song created!" });
        }catch(Exception e){
            if (e is KeyNotFoundException){
                return NotFound(new {Message = e.Message});
            }
            return NotFound(new {Message = "Song NOT created!"});
        }
    }

    [HttpPut("{id}")]
    [ActionName("UpdateData")]
    public IActionResult Update([FromBody] Song song){
        try{   
            _dbContext.Songs.Attach(song);
            _dbContext.Entry(song).State = EntityState.Modified;        
            _dbContext.SaveChanges();
            return Ok(new { Message = "Song updated!" });
        }catch{
            return NotFound(new {Message = "Song NOT updated!"});
        }
    }

    [HttpDelete("{id}")]
    [ActionName("DeleteData")]
    public IActionResult Delete(int id){
        try{
            var song = _dbContext.Songs.Find(id);
            if (song == null) {
                throw new KeyNotFoundException("Song not found!");
            }
            _dbContext.Songs.Remove(song);
            _dbContext.SaveChanges();
            return Ok(new { Message = "Song deleted!" });
        }catch(Exception e){
            return NotFound(new {Message = "Song NOT deleted!"});
        }
        
    }
}