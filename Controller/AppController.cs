using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyToDoApp.Models;

namespace MyToDoApp.Controller;


[Route("api/application")]
[ApiController]
public class AppController: ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public AppController(AppDbContext dbContext, IMapper mapper)
    {
      _db = dbContext;
      _mapper = mapper;
      
    }

}