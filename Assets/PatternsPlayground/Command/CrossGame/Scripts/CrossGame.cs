using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cross game is receiver
public class CrossGame : MonoBehaviour
{
    public const int PlayersCount = 2;
    [SerializeField] private Vector2Int _fieldSize;
    [SerializeField] private List<CrossGameCell> _cells;
    private int _CurrentPlayer;
    private StackCommandInvoker _stackCommandInvoker;
    private void Start()
    {
        _stackCommandInvoker = new StackCommandInvoker();
        for (var index = 0; index < _cells.Count; index++)
        {
            var gameCell = _cells[index];
            gameCell.Position = new Vector2Int(index % _fieldSize.x, index / _fieldSize.y);
            gameCell.OnClick += OnClickCell;
        }
    }
    
    private void OnClickCell(CrossGameCell cell)
    {
        _stackCommandInvoker.AddAndExecuteCommand(new PlayerTurnCommand(this, _CurrentPlayer, cell.Position));
    }

    public void CaptureCell(int playerID, Vector2Int coords)
    {
        _cells[coords.x + coords.y * _fieldSize.x].SetPlayer(playerID);
        _CurrentPlayer = (playerID + 1) % PlayersCount;
    }

    public void FreeCell(int playerID, Vector2Int coords)
    {
        _cells[coords.x + coords.y * _fieldSize.x].SetPlayer(-1);
        _CurrentPlayer = playerID;
    }

    public void ClearLastTurn()
    {
        _stackCommandInvoker.CancelLast();
    }

    public void ClearManyLastTurn(int count)
    {
        _stackCommandInvoker.CancelManyLast(count);
    }
    private void OnDestroy()
    {
        for (var index = 0; index < _cells.Count; index++)
        {
            var gameCell = _cells[index];
            gameCell.OnClick -= OnClickCell;
        }
    }
}
