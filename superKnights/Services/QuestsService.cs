using System;
using System.Collections.Generic;
using superKnights.Models;
using superKnights.Repositories;

namespace superKnights.Services
{
  public class QuestsService
  {
    private readonly QuestsRepository _qrepo;
    private readonly KnightQuestRepository _kqrepo;

    public QuestsService(QuestsRepository qrepo, KnightQuestRepository kqrepo)
    {
      _qrepo = qrepo;
      _kqrepo = kqrepo;
    }

    public Quest Create(Quest data)
    {
      return _qrepo.Create(data);
    }

    public List<Quest> GetAll()
    {
      return _qrepo.GetAll();
    }

    public List<KnightQuest> GetKnightsByQuestId(int id)
    {
      // do the biz
      return _kqrepo.GetKnightsByQuestId(id);
    }
  }
}