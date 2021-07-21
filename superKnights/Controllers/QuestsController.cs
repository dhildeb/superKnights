using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using superKnights.Models;
using superKnights.Services;

namespace superKnights.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class QuestsController : ControllerBase
  {
    private readonly QuestsService _ks;

    public QuestsController(QuestsService ks)
    {
      _ks = ks;
    }
    [HttpPost]
    public ActionResult<Quest> Create([FromBody] Quest data)
    {


      try
      {
        Quest Quest = _ks.Create(data);
        return Ok(Quest);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Quest>> GetAll()
    {
      try
      {
        List<Quest> Quests = _ks.GetAll();
        return Ok(Quests);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{id}/knights")]
    public ActionResult<List<Knight>> GetKnightsByQuestId(int id)
    {
      try
      {
        List<KnightQuest> Knights = _ks.GetKnightsByQuestId(id);
        return Ok(Knights);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}
