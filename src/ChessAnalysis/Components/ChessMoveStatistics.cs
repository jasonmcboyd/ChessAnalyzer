using ChessAnalysis.Models;

namespace ChessAnalysis.Components
{
  public class ChessMoveStatistics
  {
    public BoardAddress FromAddress { get; set; }
    public BoardAddress ToAddress { get; set; }
    public decimal WinPercentage { get; set; }
    public ChessPieceType PieceType { get; set; }
  }
}
