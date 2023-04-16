namespace ChessAnalysis.Models
{
  public class Move
  {
    public Move(
      BoardAddress fromAddress,
      BoardAddress toAddress,
      ChessPieceType pieceType)
    {
      FromAddress = fromAddress;
      ToAddress = toAddress;
      PieceType = pieceType;
    }

    public BoardAddress FromAddress { get; }
    public BoardAddress ToAddress { get; }
    public ChessPieceType PieceType { get; }
  }
}
