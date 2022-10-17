namespace SchneiderElectric.Minesweeper.Emil.Services;

public class PlayerService : IPlayerService
{
    public Task<Player> NewPlayerAsync(string playerName)
    {
        if (string.IsNullOrWhiteSpace(playerName))
        {
            throw new ArgumentNullException("Please enter your name");
        }

        return Task.Run(() =>
        {
            return new Player(
                name: playerName,
                lives: GameConstants.NumberOfLives);
        });
    }

    public Task SetPlayerInitialPositionAsync(Cell[][] board)
    {
        return Task.Run(() =>
        {
            var cellsIndexesWhitoutBomb = new List<int>();

            for (int i = 0; i < board[0].Length; i++)
            {
                if (!board[0][i].HasBomb)
                {
                    cellsIndexesWhitoutBomb.Add(i);
                }
            }
            var random = new Random();
            var randomListIndex = random.Next(cellsIndexesWhitoutBomb.Count);

            board[0][cellsIndexesWhitoutBomb[randomListIndex]].PlayerPosition = true;
        });
    }

    public Task GetPlayerCurrentPositionAsync(
        Cell[][] board,
        Player player)
    {
        return Task.Run(async () =>
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {

                    if (board[i][j].PlayerPosition)
                    {
                        player.CurrentPossition = MapFromArrayPossitionToString(i, j + 1);
                        break;
                    }
                }
            }
        });
    }

    private string MapFromArrayPossitionToString(
        int rowIndex,
        int columnIndex)
    {
        return MapNumberToLetter.GetLetterFromNumber(rowIndex) + columnIndex;
    }
}
