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

public class SongController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public SongController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [ActionName("GetData")]
    public IActionResult GetData(int ? stupac = null, string ? parameter = null){
        try{
            return Ok(_dbContext.Songs.ToArray());

        }catch(Exception e){
            Console.WriteLine(e.StackTrace);
            return NotFound();
        }

        return Ok();
    }
}

//		where {stupac} like {parameter}