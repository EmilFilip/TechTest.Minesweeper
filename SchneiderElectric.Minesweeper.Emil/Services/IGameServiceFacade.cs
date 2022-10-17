namespace SchneiderElectric.Minesweeper.Emil.Services;

public interface IGameServiceFacade
{
    Task<Cell[][]> StartNew(
        DifficultyLevel difficultyLevel,
        Player player);
}
