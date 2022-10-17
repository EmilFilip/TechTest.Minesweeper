namespace SchneiderElectric.Minesweeper.Emil.Models;

public class Player
{
    public Player(
        string name,
        int lives)
    {
        Name = name;
        Lives = lives;
    }

    public string Name { get; set; }

    [DefaultValue(0)]
    public int Moves { get; set; }

    public int Lives { get; set; }

    public string CurrentPossition { get; set; }
}
