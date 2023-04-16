namespace ChessAnalysis.Models
{
  public class BoardSquare
  {
    public BoardSquare(BoardAddress address)
    {
      Address = address;
    }

    public BoardAddress Address { get; }
    public ChessPiece? CurrentPiece { get; set; }
    //public List<ChessMoveStatistics> MoveStatistics { get; set; } = new List<ChessMoveStatistics>();

    public ChessColor SquareColor => ((int)Address.File + (int)Address.Rank) % 2 == 0 ? ChessColor.Black : ChessColor.White;

    //public void AddMoveStatistics(ChessPieceType pieceType, BoardAddress fromAddress, BoardAddress toAddress, bool won)
    //{
    //  var existingStatistics = MoveStatistics.Find(s => s.PieceType == pieceType && s.FromAddress.Equals(fromAddress) && s.ToAddress.Equals(toAddress));
    //  if (existingStatistics != null)
    //  {
    //    existingStatistics.AddResult(won);
    //  }
    //  else
    //  {
    //    var statistics = new ChessMoveStatistics(pieceType, fromAddress, toAddress);
    //    statistics.AddResult(won);
    //    MoveStatistics.Add(statistics);
    //  }
    //}

    //public float GetWinPercentage()
    //{
    //  if (MoveStatistics.Count == 0)
    //  {
    //    return 0.5f;
    //  }

    //  int wins = 0;
    //  foreach (var move in MoveStatistics)
    //  {
    //    wins += move.Wins;
    //  }

    //  return (float)wins / MoveStatistics.Count;
    //}
  }
}
