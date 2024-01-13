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

public class BandController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public BandController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [ActionName("GetData")]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
    public IActionResult GetData(){
        try{
            return Ok(_dbContext.Bands.ToArray());
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
            var band = _dbContext.Bands.Find(id);
            if (band == null) {
                throw new KeyNotFoundException("Band not found!");
            }
            return Ok(band);
        }catch(Exception e){
            return NotFound();
        }
    }

    [HttpPost]
    [ActionName("PostData")]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
    public IActionResult PostData([FromBody] BandDTO dto ){
        try{
            Band band = new Band(dto);
            _dbContext.Add(band);
            _dbContext.SaveChanges();
            return Ok(band);
        }catch(Exception e){
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound)]
    [ActionName("UpdateData")]
    public IActionResult Update([FromBody] Band band){
        try{   
            _dbContext.Bands.Attach(band);
            _dbContext.Entry(band).State = EntityState.Modified;        
            _dbContext.SaveChanges();
            return Ok(band);
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
            var band = _dbContext.Bands.Find(id);
            if (band == null) {
                throw new KeyNotFoundException("Resource not found");
            }
            _dbContext.Bands.Remove(band);
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