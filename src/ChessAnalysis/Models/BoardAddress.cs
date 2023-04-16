namespace ChessAnalysis.Models
{
  public class BoardAddress : IEquatable<BoardAddress>
  {
    public BoardAddress(Rank rank, File file)
    {
      Rank = rank;
      File = file;
    }

    public static BoardAddress Parse(string addressString)
    {
      var file = addressString[0] - 'a';
      var rank = addressString[1] - '1';

      return new BoardAddress((Rank)rank, (File)file);
    }
    public Rank Rank { get; }
    public File File { get; }

    public override string ToString() => $"{File}{(int)Rank + 1}";

    public override bool Equals(object? obj) => Equals(obj as BoardAddress);

    public bool Equals(BoardAddress? other) => Rank == other?.Rank && File == other?.File;

    public override int GetHashCode() => (Rank, File).GetHashCode();
  }
}
