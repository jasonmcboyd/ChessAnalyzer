namespace ChessAnalysis.Models
{
  public class ChessPiece
  {
    public ChessPiece(ChessPieceType pieceType, ChessColor color)
    {
      PieceType = pieceType;
      Color = color;
    }

    public ChessPieceType PieceType { get; }
    public ChessColor Color { get; }
  }
}
