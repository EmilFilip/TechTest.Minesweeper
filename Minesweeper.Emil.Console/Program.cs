var name = string.Empty;
Player player;
while (string.IsNullOrEmpty(name))
{
    Console.WriteLine("Please enter your name");
    name = Console.ReadLine();
}

IPlayerService initiatePlayer = new PlayerService();
player = await initiatePlayer.NewPlayerAsync(name);

var dificultyLevel = DifficultyLevel.None;
var dificultyLevelInput = 0;
var isNumeric = false;
while (
    (dificultyLevel != DifficultyLevel.Beginner &&
    dificultyLevel != DifficultyLevel.Medium &&
    dificultyLevel != DifficultyLevel.Hard) ||
    !isNumeric)
{
    Console.Clear();
    Console.WriteLine($"Hello {name}. Please select difficulty level to start a new game: 1 = Beginner; 2 = Medium; 3 = Hard");
    isNumeric = int.TryParse(Console.ReadLine(), out dificultyLevelInput);
    dificultyLevel = (DifficultyLevel)dificultyLevelInput;
}

IGameServiceFacade gameServiceFacade = new GameServiceFacade();
var board = await gameServiceFacade.StartNew(dificultyLevel, player);

var gameOn = true;
var arrowKey = ConsoleKey.NoName;
while (gameOn)
{
    while (
        (arrowKey != ConsoleKey.UpArrow &&
        arrowKey != ConsoleKey.DownArrow &&
        arrowKey != ConsoleKey.LeftArrow) &&
        arrowKey != ConsoleKey.RightArrow)
    {
        Console.Clear();
        Console.WriteLine($"=======Your curent position is {player.CurrentPossition}. You have {player.Lives} lives left. You have used {player.Moves} moves so far=======");
        Console.WriteLine("");
        Console.WriteLine("Please navigate through mines using arrows on your keyboard to reach the other side of the board");
        arrowKey = Console.ReadKey(false).Key;
    }

    IBoardService boardService = new BoardService();
    await boardService.NavigateToNextCell(
        board,
        arrowKey);

    gameOn = false;
}

Console.ReadKey();
