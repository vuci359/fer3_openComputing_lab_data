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

public class BandController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public BandController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [ActionName("GetData")]
    public IActionResult GetData(){
        try{
            return Ok(_dbContext.Bands.ToArray());
        }catch(Exception e){
            return NotFound(new {Message = "No bands found!"});
        }
    }

    [HttpGet("{id}")]
    [ActionName("GetDataById")]
    public IActionResult GetDataById(int ? id = null){
        try{
            var band = _dbContext.Bands.Find(id);
            if (band == null) {
                throw new KeyNotFoundException("Band not found!");
            }
            return Ok(band);
        }catch(Exception e){
            return NotFound(new {Message = "Band NOT found!"});
        }
    }

    [HttpPost]
    [ActionName("PostData")]
    public IActionResult PostData([FromBody] Band band ){
        try{
            var bandExist = _dbContext.Bands.Any(e => e.ident == band.ident);
            if (bandExist == true){
                return Ok(new { Message = "Band already created!" });                    
            }
            _dbContext.Add(band);
            _dbContext.SaveChanges();
            return Ok(new { Message = "Band created!" });
        }catch(Exception e){
            return NotFound(new {Message = "Band NOT created!"});
        }
    }

    [HttpPut("{id}")]
    [ActionName("UpdateData")]
    public IActionResult Update([FromBody] Band band){
        try{   
            _dbContext.Bands.Attach(band);
            _dbContext.Entry(band).State = EntityState.Modified;        
            _dbContext.SaveChanges();
            return Ok(new { Message = "Band updated!" });
        }catch{
            return NotFound(new {Message = "Band NOT updated!"});
        }
    }

    [HttpDelete("{id}")]
    [ActionName("DeleteData")]
    public IActionResult Delete(int id){
        try{
            var band = _dbContext.Bands.Find(id);
            if (band == null) {
                throw new KeyNotFoundException("Band not found!");
            }
            _dbContext.Bands.Remove(band);
            _dbContext.SaveChanges();
            return Ok(new { Message = "Song deleted!" });
        }catch(Exception e){
            if (e is KeyNotFoundException){
                return NotFound(new {Message = e.Message});
            }
            return NotFound(new {Message = "Song NOT deleted!"});
        }
        
    }
}