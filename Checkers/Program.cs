// See https://aka.ms/new-console-template for more information

public static class Program
{
    public static void Main(string[] args)
    {
    }
}

public class Board
{
    private readonly Tile[,] _board;

    public Board()
    {
        var edgeSize = 8;
        _board = new Tile[edgeSize, edgeSize];
        InitializeTiles(edgeSize);
        FillPieces(edgeSize);
    }

    public Board(int edgeSize, IEnumerable<Piece> pieces)
    {
        throw new NotImplementedException();
    }


    private void FillPieces(int edgeSize)
    {
        // Fill first three rows with White
        for (var row = 0; row < 3; row++)
        {
            for (var column = 0; column < edgeSize; column++)
            {
                Tile tile = GetTile(row, column);
                if (tile.Color == TileColor.Black)
                {
                    tile.Piece = new Piece(PieceColor.White);
                }
            }
        }

        for (var row = 5; row < edgeSize; row++)
        {
            for (var column = 0; column < edgeSize; column++)
            {
                Tile tile = GetTile(row, column);
                if (tile.Color == TileColor.Black)
                {
                    tile.Piece = new Piece(PieceColor.Black);
                }
            }
        }
    }

    private void InitializeTiles(int edgeSize)
    {
        for (var row = 0; row < edgeSize; row++)
        {
            for (var column = 0; column < edgeSize; column++)
            {
                _board[row, column] = (row + column) % 2 == 0
                    ? new Tile(TileColor.White)
                    : new Tile(TileColor.Black);
            }
        }
    }

    public Tile GetTile(int row, int column)
    {
        return _board[row, column];
    }
}

public class Tile
{
    public Tile(TileColor tileColor)
    {
        Color = tileColor;
    }

    public TileColor Color { get; set; }
    public Piece? Piece { get; set; }
}

public class Piece
{
    public Piece(PieceColor pieceColor)
    {
        Color = pieceColor;
    }

    public PieceColor Color { get; set; }
}

public enum PieceColor
{
    White,
    Black
}

public enum TileColor
{
    White,
    Black
}