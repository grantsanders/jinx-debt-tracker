namespace jinx_debt_tracker.Models;

public class Game
{
    public int ID { get; set; }
    public int Player1_ID { get; set; }
    public int Player2_ID { get; set; }
    public int Player1_Score { get; set; }
    public int Player2_Score { get; set; }
    public DateTime LastModifyDate { get; set; }
}