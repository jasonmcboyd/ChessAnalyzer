using System.Text.RegularExpressions;
using ChessAnalysis.Models;

namespace ChessAnalysis.Utilities
{
  public static class PgnFileParser
  {
    private static readonly Regex HeaderRegex = new Regex(@"^\[(?<tag>.*)\s""(?<value>.*)""\]$");
    private static readonly Regex MoveRegex = new Regex(@"^(?<moveNumber>\d+)\.\s*(?<san>.*?)\s*$");

    public static List<ChessGameRecord> ParsePgnFile(StreamReader reader)
    {
      var chessGameRecords = new List<ChessGameRecord>();

      ChessGameRecord? currentRecord = null;

      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(line))
        {
          continue;
        }

        if (line.StartsWith("["))
        {
          var headerMatch = HeaderRegex.Match(line);
          if (headerMatch.Success)
          {
            if (currentRecord == null)
            {
              currentRecord = new ChessGameRecord();
            }

            var tag = headerMatch.Groups["tag"].Value.ToUpperInvariant();
            var value = headerMatch.Groups["value"].Value;

            switch (tag)
            {
              case "EVENT":
                currentRecord.Event = value;
                break;
              case "SITE":
                currentRecord.Site = value;
                break;
              case "DATE":
                if (DateTime.TryParse(value, out DateTime dateValue))
                  currentRecord.Date = dateValue;
                break;
              case "WHITE":
                currentRecord.White = value;
                break;
              case "BLACK":
                currentRecord.Black = value;
                break;
              case "RESULT":
                if (value == "1-0")
                  currentRecord.Result = ChessColor.White;
                else if (value == "0-1")
                  currentRecord.Result = ChessColor.Black;
                else
                  currentRecord.Result = null;
                break;
              case "TERMINATION":
                currentRecord.Termination = value;
                break;
              default:
                break;
            }
          }
        }
        else
        {
          if (currentRecord != null)
          {
            var moveMatch = MoveRegex.Match(line);
              
            if (moveMatch.Success)
              currentRecord.Moves = ParseMoves(line);
          }
        }
      }

      if (currentRecord != null)
      {
        chessGameRecords.Add(currentRecord);
      }

      return chessGameRecords;
    }

    public static List<Move> ParseMoves(string moveString)
    {
      var moves = new List<Move>();
      var moveTokens = moveString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

      ChessColor color = ChessColor.White;
      BoardAddress? fromAddress = null;
      foreach (var moveToken in moveTokens)
      {
        if (moveToken.EndsWith("."))
        {
          continue;
        }

        if (char.IsDigit(moveToken[0]))
        {
          // New move number
          color = color == ChessColor.White ? ChessColor.Black : ChessColor.White;
        }
        else
        {
          // Move
          BoardAddress toAddress = BoardAddress.Parse(moveToken.Substring(0, 2));
          ChessPieceType pieceType = default;

          // Check for promotion
          if (moveToken.Length == 5 && moveToken.EndsWith("="))
          {
            pieceType = GetPieceTypeFromSymbol(moveToken[4]);
          }

          if (fromAddress != null)
          {
            moves.Add(new Move(fromAddress, toAddress, pieceType));
            fromAddress = null;
          }
          else
          {
            fromAddress = toAddress;
          }
        }
      }

      var test = moves[0].FromAddress.ToString();

      return moves;
    }

    private static ChessPieceType GetPieceTypeFromSymbol(char symbol)
    {
      switch (symbol)
      {
        case 'N':
          return ChessPieceType.Knight;
        case 'B':
          return ChessPieceType.Bishop;
        case 'R':
          return ChessPieceType.Rook;
        case 'Q':
          return ChessPieceType.Queen;
        case 'K':
          return ChessPieceType.King;
        default:
          throw new Exception();
      }
    }
  }
}
