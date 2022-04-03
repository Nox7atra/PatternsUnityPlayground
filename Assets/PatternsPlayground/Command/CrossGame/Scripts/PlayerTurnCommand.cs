using UnityEngine;

public class PlayerTurnCommand : ICommand
{
    private CrossGame _Game;
    private int _PlayerID;
    private Vector2Int _Coords;
    public PlayerTurnCommand(CrossGame game, int playerID, Vector2Int coords)
    {
        _Game = game;
        _PlayerID = playerID;
        _Coords = coords;
    }

    public void Execute()
    {
        _Game.CaptureCell(_PlayerID, _Coords);
    }

    public void Undo()
    {
        _Game.FreeCell(_PlayerID, _Coords);
    }
}
