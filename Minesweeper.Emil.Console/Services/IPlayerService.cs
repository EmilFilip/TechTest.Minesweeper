namespace Minesweeper.Emil.Services;

public interface IPlayerService
{
    Task<Player> NewPlayerAsync(string playerName);

    Task SetPlayerInitialPositionAsync(Cell[][] board);

    Task GetPlayerCurrentPositionAsync(
        Cell[][] board,
        Player player);
}
