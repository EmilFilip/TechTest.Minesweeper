namespace SchneiderElectric.Minesweeper.Emil.Services;

public class BoardService : IBoardService
{
    public Task<Cell[][]> CreateAsync(int size)
    {
        return Task.Run(() =>
        {
            var board = new Cell[size][];

            for (int i = 0; i < size; i++)
            {
                board[i] = new Cell[size];

                for (int j = 0; j < board.Length; j++)
                {
                    board[i][j] = new Cell();
                }
            }

            return board;
        });
    }

    public Task PopulateWithBombsAsync(
        Cell[][] board,
        DifficultyLevel difficultyLevel)
    {
        return Task.Run(() =>
        {
            var numberOfBombs = 0;

            switch (difficultyLevel)
            {
                case DifficultyLevel.Beginner:
                    numberOfBombs = GameConstants.BeginnerNumberOfBombsPerRow;
                    break;
                case DifficultyLevel.Medium:
                    numberOfBombs = GameConstants.MediumNumberOfBombsPerRow;
                    break;
                case DifficultyLevel.Hard:
                    numberOfBombs = GameConstants.HardNumberOfBombsPerRow;
                    break;
                default:
                    throw new ArgumentNullException("Please select a difficulty level");
            }

            for (int i = 0; i < board.Length; i++)
            {
                var random = new Random();
                List<int> bombPlaces = Enumerable.Range(0, board[i].Length).OrderBy(_ => random.Next()).Take(numberOfBombs).ToList();

                for (int j = 0; j < board[i].Length; j++)
                {
                    if (bombPlaces.Contains(j))
                    {
                        board[i][j].HasBomb = true;
                    }
                }
            }
        });
    }

    public Task NavigateToNextCell(
        Cell[][] board,
        ConsoleKey arrowKey)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"You navigated {arrowKey.ToString().Replace("Arrow", "")}");
        });
    }
}
