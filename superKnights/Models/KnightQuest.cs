namespace superKnights.Models
{
  public class KnightQuest
  {
    public int Id { get; set; }
    public int QuestId { get; set; }
    public int KnightId { get; set; }

    public Knight Knight { get; set; }
    public Quest Quest { get; set; }

  }
}