using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using superKnights.Models;

namespace superKnights.Repositories
{
  public class KnightsRepository
  {
    private readonly IDbConnection _db;

    public KnightsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Knight Create(Knight data)
    {
      string sql = @"
      INSERT INTO knights (name) 
      VALUES (@Name); 
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }
    public List<Knight> GetAll()
    {
      string sql = "SELECT * FROM knights";
      return _db.Query<Knight>(sql).ToList();
    }
    // public Knight GetById(int id){

    // }
  }

}