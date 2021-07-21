// delete and post for the relationship no need for edit
using Microsoft.AspNetCore.Mvc;
using superKnights.Models;
using superKnights.Services;

namespace superKnights
{
  [ApiController]
  [Route("api/[controller]")]
  public class KnightQuestController : ControllerBase
  {
    private readonly KnightQuestService _kqs;

    public KnightQuestController(KnightQuestService kqs)
    {
      _kqs = kqs;
    }
    [HttpPost]
    //                                                                  vvvv data/ids provided by the user
    public ActionResult<KnightQuest> AcceptQuest([FromBody] KnightQuest kqData)
    {
      try
      {
        KnightQuest KnightQuest = _kqs.AcceptQuest(kqData);
        return Ok(KnightQuest);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}