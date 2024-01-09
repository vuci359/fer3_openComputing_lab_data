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
[Route("api/[controller]")]
[Produces("application/json")]
[EnableCors]

public class AlbumController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public AlbumController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [ActionName("GetData")]
    public IActionResult GetData(){
        try{
            return Ok(_dbContext.Albums.ToArray());
        }catch(Exception e){
            return NotFound(new {Message = "No albums found!"});
        }
    }

    [HttpGet("{id}")]
    [ActionName("GetDataById")]
    public IActionResult GetDataById(int ? id = null){
        try{
            var album = _dbContext.Albums.Find(id);
            if (album == null) {
                throw new KeyNotFoundException("Album not found!");
            }
            return Ok(album);
        }catch(Exception e){
            return NotFound(new {Message = "Album NOT found!"});
        }
    }

    [HttpPost]
    [ActionName("PostData")]
    public IActionResult PostData([FromBody] Album album ){

        try{var albumExist = _dbContext.Albums.Any(e => e.ident == album.ident);
            if (albumExist == true){
                return Ok(new { Message = "Album already created!" });                    
            }
            _dbContext.Add(album);
            _dbContext.SaveChanges();
            return Ok(new { Message = "Album created!" });
        }catch(Exception e){
            return NotFound(new {Message = "Album NOT created!"});
        }
    }

    [HttpPut("{id}")]
    [ActionName("UpdateData")]
    public IActionResult Update([FromBody] Album album){
        try{   
            _dbContext.Albums.Attach(album);
            _dbContext.Entry(album).State = EntityState.Modified;        
            _dbContext.SaveChanges();
            return Ok(new { Message = "Album updated!" });
        }catch{
            return NotFound(new {Message = "Album NOT updated!"});
        }
    }

    [HttpDelete("{id}")]
    [ActionName("DeleteData")]
    public IActionResult Delete(int id){
        try{
            var album = _dbContext.Albums.Find(id);
            if (album == null) {
                throw new KeyNotFoundException("Album not found!");
            }
            _dbContext.Albums.Remove(album);
            _dbContext.SaveChanges();
            return Ok(new { Message = "Album deleted!" });
        }catch(Exception e){
            if (e is KeyNotFoundException){
                return NotFound(new {Message = e.Message});
            }
            return NotFound(new {Message = "Album NOT deleted!"});
        }
        
    }
}