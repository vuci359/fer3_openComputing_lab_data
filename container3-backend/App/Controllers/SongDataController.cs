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
    public IActionResult GetData(string ? stupac = null, string ? parameter = null){

		try{
            var SongData = _dbContext.Songs.Include(s => s.Album).ThenInclude(a => a.Band).ToList();
            return Ok(SongData);

        }catch(Exception e){
            Console.WriteLine(e.StackTrace);
        }

        return Ok();
    }
}

//		where {stupac} like {parameter}