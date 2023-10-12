using FluentAssertions;

namespace Checkers.Tests;

public class CheckerBoardTests
{
    [Fact]
    public void Board_Should_StartWithWhiteTileFollowedByBlack()
    {
        // Arrange and Act
        var board = new Board();

        // Assert
        board.GetTile(0, 0).Color.Should().Be(TileColor.White);
        board.GetTile(0, 1).Color.Should().Be(TileColor.Black);
        board.GetTile(0, 2).Color.Should().Be(TileColor.White);
        board.GetTile(1, 0).Color.Should().Be(TileColor.Black);
        board.GetTile(1, 1).Color.Should().Be(TileColor.White);
        board.GetTile(1, 2).Color.Should().Be(TileColor.Black);
    }

    [Fact]
    public void Board_Should_HavePiecesInCorrectPlaces()
    {
        // Arrange & Act
        var board = new Board();

        // Assert
        for (var row = 0; row < 3; row++)
        {
            for (var column = 0; column < 8; column++)
            {
                if ((row + column) % 2 == 0)
                {
                    board.GetTile(row, column).Piece.Should().BeNull();
                }
                else
                {
                    board.GetTile(row, column).Piece!.Color.Should()
                        .Be(PieceColor.White);
                }
            }
        }

        for (int row = 3; row < 5; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                board.GetTile(row, column).Piece.Should().BeNull();
            } 
        }
        
        for (var row = 5; row < 8; row++)
        {
            for (var column = 0; column < 8; column++)
            {
                if ((row + column) % 2 == 0)
                {
                    board.GetTile(row, column).Piece.Should().BeNull();
                }
                else
                {
                    board.GetTile(row, column).Piece!.Color.Should()
                        .Be(PieceColor.Black);
                }
            }
        }
    }
}