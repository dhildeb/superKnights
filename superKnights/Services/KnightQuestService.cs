using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using superKnights.Models;
using superKnights.Repositories;

namespace superKnights.Services
{
  public class KnightQuestService
  {
    private readonly KnightQuestRepository _kqrepo;

    public KnightQuestService(KnightQuestRepository kqrepo)
    {
      _kqrepo = kqrepo;
    }

    public KnightQuest AcceptQuest(KnightQuest data)
    {
      return _kqrepo.AcceptQuest(data);
    }

  }
}