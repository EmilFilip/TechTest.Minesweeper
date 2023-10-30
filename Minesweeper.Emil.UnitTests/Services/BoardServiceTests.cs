namespace Minesweeper.Emil.UnitTests.Services;

public class BoardServiceTests
{
    protected Cell[][] _board;
    private Fixture _fixture;
    protected BoardService _sut;

    public BoardServiceTests()
    {
        _fixture = new Fixture();
        _sut = new BoardService();
    }


    [Theory]
    [InlineData(DifficultyLevel.Beginner, GameConstants.BeginnerNumberOfBombsPerRow)]
    [InlineData(DifficultyLevel.Medium, GameConstants.MediumNumberOfBombsPerRow)]
    [InlineData(DifficultyLevel.Hard, GameConstants.HardNumberOfBombsPerRow)]
    public async void PopulateWithBombsAsync_WhenPassingTheCorrectDifficultyLevel_PopulatesBoard(
        DifficultyLevel difficultyLevel,
        int expectedNumberOfBombs)
    {
        // Arrange
        _board = new Cell[GameConstants.BoardSize][];
        for (int i = 0; i < _board.Length; i++)
        {
            _board[i] = _fixture.Build<Cell>().With(x => x.HasBomb, false).CreateMany(GameConstants.BoardSize).ToArray();
        }

        // Act
        await _sut.PopulateWithBombsAsync(_board, difficultyLevel);

        // Assert
        Assert.NotNull(_board);
        for (int i = 0; i < _board.Length; i++)
        {
            var bombCount = _board[i].Where(x => x.HasBomb).Count();
            Assert.Equal(expectedNumberOfBombs, bombCount);
        }
    }

    [Fact]
    public async void PopulateWithBombsAsync_WhenPassingTheWrongDifficultyLevel_ThrowsArgumentNullException()
    {
        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _sut.PopulateWithBombsAsync(It.IsAny<Cell[][]>(), DifficultyLevel.None));
    }

    [Fact]
    public async void CreateAsync_WhenPassingTheWrongDifficultyLevel_ThrowsArgumentNullException()
    {
        // Act
        var board = await _sut.CreateAsync(GameConstants.BoardSize);

        //Assert
        Assert.NotNull(board);
        for (int i = 0; i < board.Length; i++)
        {
            Assert.Equal(GameConstants.BoardSize, board[i].Length);
        }
    }
}
