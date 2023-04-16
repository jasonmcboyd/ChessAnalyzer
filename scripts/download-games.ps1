[CmdletBinding()]
param (
  [string]
  $Username = 'jasonboydce'
)

$url = "https://api.chess.com/pub/player/$Username/games/2022/12"

Invoke-RestMethod -Uri $url
