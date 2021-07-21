using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using superKnights.Models;

namespace superKnights.Repositories
{
  public class KnightQuestRepository
  {
    private readonly IDbConnection _db;

    public KnightQuestRepository(IDbConnection db)
    {
      _db = db;
    }

    public KnightQuest AcceptQuest(KnightQuest data)
    {
      string sql = @"INSERT INTO knight_quest
      (knightId, questId)
      VALUES
      (@KnightId, @QuestId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;

    }
    public List<KnightQuest> GetKnightsByQuestId(int questId)
    {
      string sql = @"
      SELECT 
      k.*,
      kq.*
      FROM knight_quest kq
      JOIN knights k ON k.id = kq.knightId
      WHERE kq.questId = @questId;";
      return _db.Query<KnightQuest, Knight, KnightQuest>(sql, (kq, k) =>
      {
        kq.Knight = k;
        return kq;
      }, new { questId }, splitOn: "id").ToList();
    }
  }
}