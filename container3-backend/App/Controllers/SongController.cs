using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using static Microsoft.AspNetCore.Http.StatusCodes;

using openComputingLab.Data;
using openComputingLab.Models;
using openComputingLab.DTO;
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
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
    public IActionResult GetData(){
        try{
            return Ok(_dbContext.Songs.ToArray());
        }catch(Exception e){
            return NotFound(new {Message = "No songs found!"});
        }
    }

    [HttpGet("{id}")]
    [ActionName("GetDataById")]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
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
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
    public IActionResult PostData([FromBody] SongDTO dto ){
        try{
            Song song = new Song(dto);
            _dbContext.Add(song);
            _dbContext.SaveChanges();
            return Ok(new { Message = "Song created!", song});
        }catch(Exception e){
            if (e is KeyNotFoundException){
                return NotFound(new {Message = e.Message});
            }
            return NotFound(new {Message = "Song NOT created!"});
        }
    }

    [HttpPut("{id}")]
    [ActionName("UpdateData")]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
    public IActionResult Update([FromBody] Song song){
        try{   
            _dbContext.Songs.Attach(song);
            _dbContext.Entry(song).State = EntityState.Modified;        
            _dbContext.SaveChanges();
            return Ok(new { Message = "Song updated!", song});
        }catch{
            return NotFound(new {Message = "Song NOT updated!"});
        }
    }

    [HttpDelete("{id}")]
    [ActionName("DeleteData")]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
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