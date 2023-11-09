using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Versioning;
using openComputingLab.Models;
using openComputingLab.Data;

namespace openComputingLab.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HeavyMetalDataController: ControllerBase{
    private readonly AppDbContext _dbContext;

    public HeavyMetalDataController(AppDbContext dbContext){
        _dbContext = dbContext;
    }
}