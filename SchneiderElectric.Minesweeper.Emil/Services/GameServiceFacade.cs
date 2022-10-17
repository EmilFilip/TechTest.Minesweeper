namespace SchneiderElectric.Minesweeper.Emil.Services;

public class GameServiceFacade : IGameServiceFacade
{
    private readonly IBoardService _boardService;
    private readonly IPlayerService _playerService;

    //poor man's DI
    public GameServiceFacade() : this(
        new BoardService(),
        new PlayerService())
    {
    }

    public GameServiceFacade(
        IBoardService boardService,
        IPlayerService playerService)
    {
        _boardService = boardService;
        _playerService = playerService;
    }

    public async Task<Cell[][]> StartNew(
        DifficultyLevel difficultyLevel,
        Player player)
    {
        var board = await _boardService.CreateAsync(GameConstants.BoardSize);

        await _boardService.PopulateWithBombsAsync(
            board,
            difficultyLevel);

        await _playerService.SetPlayerInitialPositionAsync(board);

        await _playerService.GetPlayerCurrentPositionAsync(
            board,
            player);

        return board;
    }
}
