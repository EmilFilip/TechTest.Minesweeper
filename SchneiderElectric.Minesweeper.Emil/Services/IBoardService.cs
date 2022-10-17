namespace SchneiderElectric.Minesweeper.Emil.Services;

public interface IBoardService
{
    Task<Cell[][]> CreateAsync(int size);

    Task PopulateWithBombsAsync(
        Cell[][] board,
        DifficultyLevel difficultyLevel);

    Task NavigateToNextCell(
        Cell[][] board,
        ConsoleKey arrowKey);
}
