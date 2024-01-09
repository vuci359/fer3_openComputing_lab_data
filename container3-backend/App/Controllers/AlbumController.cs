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

public class AlbumController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public AlbumController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [ActionName("GetData")]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
    public IActionResult GetData(){
        try{
            return Ok(_dbContext.Albums.ToArray());
        }catch(Exception e){
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    [ActionName("GetDataById")]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
    public IActionResult GetDataById(int ? id = null){
        try{
            var album = _dbContext.Albums.Find(id);
            if (album == null) {
                throw new KeyNotFoundException("Album not found!");
            }
            return Ok(album);
        }catch(Exception e){
            return NotFound();
        }
    }

    [HttpPost]
    [ActionName("PostData")]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
    public IActionResult PostData([FromBody] AlbumDTO dto ){

        try{
            Album album = new Album(dto);
            _dbContext.Add(album);
            _dbContext.SaveChanges();
            return Ok();
        }catch(Exception e){
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    [ActionName("UpdateData")]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
    public IActionResult Update([FromBody] Album album){
        try{   
            _dbContext.Albums.Attach(album);
            _dbContext.Entry(album).State = EntityState.Modified;        
            _dbContext.SaveChanges();
            return Ok();
        }catch{
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    [ActionName("DeleteData")]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
    public IActionResult Delete(int id){
        try{
            var album = _dbContext.Albums.Find(id);
            if (album == null) {
                throw new KeyNotFoundException("Album not found!");
            }
            _dbContext.Albums.Remove(album);
            _dbContext.SaveChanges();
            return Ok();
        }catch(Exception e){
            if (e is KeyNotFoundException){
                return NotFound();
            }
            return NotFound();
        }
        
    }
}