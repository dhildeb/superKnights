using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using superKnights.Models;
using superKnights.Services;

namespace superKnights.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KnightsController : ControllerBase
  {
    private readonly KnightsService _ks;

    public KnightsController(KnightsService ks)
    {
      _ks = ks;
    }
    [HttpPost]
    public ActionResult<Knight> Create([FromBody] Knight data)
    {


      try
      {
        Knight Knight = _ks.Create(data);
        return Ok(Knight);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    public ActionResult<List<Knight>> GetAll()
    {
      try
      {
        List<Knight> knights = _ks.GetAll();
        return Ok(knights);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // [HttpGet]
    // public ActionResult<List<Knight>> GetQuestsByKnightId()
  }
}