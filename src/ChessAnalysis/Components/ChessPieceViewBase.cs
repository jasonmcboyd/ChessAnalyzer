using ChessAnalysis.Models;
using Microsoft.AspNetCore.Components;

namespace ChessAnalysis.Components
{
  public class ChessPieceViewBase : ComponentBase
  {
    [Parameter]
    public ChessColor Color { get; set; }

    protected string FillColor => Color == ChessColor.Black ? "black" : "white";
  }
}
