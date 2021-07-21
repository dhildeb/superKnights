using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using superKnights.Models;

namespace superKnights.Repositories
{
  public class QuestsRepository
  {
    private readonly IDbConnection _db;

    public QuestsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Quest Create(Quest data)
    {
      string sql = @"
      INSERT INTO quests (title, details) 
      VALUES (@Title, @Details); 
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }
    public List<Quest> GetAll()
    {
      string sql = "SELECT * FROM quests";
      return _db.Query<Quest>(sql).ToList();
    }
  }

}