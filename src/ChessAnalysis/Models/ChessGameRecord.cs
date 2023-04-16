namespace ChessAnalysis.Models
{
  public class ChessGameRecord
  {
    public string Event { get; set; }
    public string Site { get; set; }
    public DateTime Date { get; set; }
    public string White { get; set; }
    public string Black { get; set; }
    public ChessColor? Result { get; set; }
    public string Termination { get; set; }
    public List<Move> Moves { get; set; } = new List<Move>();

    private string ResultToString()
      => Result == ChessColor.White
         ? "1-0"
         : Result == ChessColor.Black
         ? "0-1"
         : "1/2-1/2";

    public override string ToString()
    {
      return $@"
[Event ""{Event}""]
[Site ""{Site}""]
[Date ""{Date:yyyy.MM.dd}""]
[White ""{White}""]
[Black ""{Black}""]
[Result ""{ResultToString()}""]
[Termination ""{Termination}""]
";
    }
  }
}
