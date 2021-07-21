using System.Collections.Generic;
using superKnights.Models;
using superKnights.Repositories;

namespace superKnights.Services
{
  public class KnightsService
  {
    private readonly KnightsRepository _krepo;

    public KnightsService(KnightsRepository krepo)
    {
      _krepo = krepo;
    }

    public Knight Create(Knight data)
    {
      return _krepo.Create(data);
    }

    public List<Knight> GetAll()
    {
      return _krepo.GetAll();
    }
  }
}