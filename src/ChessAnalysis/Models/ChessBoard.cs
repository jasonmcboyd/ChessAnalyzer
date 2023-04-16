namespace ChessAnalysis.Models
{
  public class ChessBoard
  {
    public ChessBoard()
    {
      var ranks = new List<IReadOnlyList<BoardSquare>>();

      for (int rank = 0; rank < 8; rank++)
      {
        var row = new List<BoardSquare>();

        for (int file = 0; file < 8; file++)
        {
          var address = new BoardAddress((Rank)rank, (File)file);

          var square = new BoardSquare(address);
          row.Add(square);
        }

        ranks.Add(row.AsReadOnly());
      }

      BoardSquares = ranks.AsReadOnly();
    }

    private IReadOnlyList<IReadOnlyList<BoardSquare>> BoardSquares { get; }

    public BoardSquare this[BoardAddress address] => this[(int)address.Rank, (int)address.File];

    public BoardSquare this[int rank, int file] => BoardSquares[rank][file];
  }
}