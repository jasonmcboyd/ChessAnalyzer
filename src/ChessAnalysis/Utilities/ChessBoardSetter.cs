using ChessAnalysis.Models;

namespace ChessAnalysis.Utilities
{
  public static class ChessBoardSetter
  {
    public static void Standard(ChessBoard chessBoard)
    {
      // Initialize pawns
      for (int file = 0; file < 8; file++)
      {
        chessBoard[1, file].CurrentPiece = new ChessPiece(ChessPieceType.Pawn, ChessColor.Black);
        chessBoard[6, file].CurrentPiece = new ChessPiece(ChessPieceType.Pawn, ChessColor.White);
      }

      // Initialize other pieces
      chessBoard[0, 0].CurrentPiece = new ChessPiece(ChessPieceType.Rook, ChessColor.Black);
      chessBoard[0, 1].CurrentPiece = new ChessPiece(ChessPieceType.Knight, ChessColor.Black);
      chessBoard[0, 2].CurrentPiece = new ChessPiece(ChessPieceType.Bishop, ChessColor.Black);
      chessBoard[0, 3].CurrentPiece = new ChessPiece(ChessPieceType.Queen, ChessColor.Black);
      chessBoard[0, 4].CurrentPiece = new ChessPiece(ChessPieceType.King, ChessColor.Black);
      chessBoard[0, 5].CurrentPiece = new ChessPiece(ChessPieceType.Bishop, ChessColor.Black);
      chessBoard[0, 6].CurrentPiece = new ChessPiece(ChessPieceType.Knight, ChessColor.Black);
      chessBoard[0, 7].CurrentPiece = new ChessPiece(ChessPieceType.Rook, ChessColor.Black);

      chessBoard[7, 0].CurrentPiece = new ChessPiece(ChessPieceType.Rook, ChessColor.White);
      chessBoard[7, 1].CurrentPiece = new ChessPiece(ChessPieceType.Knight, ChessColor.White);
      chessBoard[7, 2].CurrentPiece = new ChessPiece(ChessPieceType.Bishop, ChessColor.White);
      chessBoard[7, 3].CurrentPiece = new ChessPiece(ChessPieceType.Queen, ChessColor.White);
      chessBoard[7, 4].CurrentPiece = new ChessPiece(ChessPieceType.King, ChessColor.White);
      chessBoard[7, 5].CurrentPiece = new ChessPiece(ChessPieceType.Bishop, ChessColor.White);
      chessBoard[7, 6].CurrentPiece = new ChessPiece(ChessPieceType.Knight, ChessColor.White);
      chessBoard[7, 7].CurrentPiece = new ChessPiece(ChessPieceType.Rook, ChessColor.White);

      // Clear the middle of the board.
      for (var rank = 2; rank < 6; rank++)
        for (var file = 0; file < 8; file++)
          chessBoard[rank, file].CurrentPiece = null;
    }
  }
}
