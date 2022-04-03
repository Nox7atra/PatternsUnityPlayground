using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CrossGameCell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _shapes;
    public int PlayerId { get; private set; } = -1;
    
    public Vector2Int Position { get; set; }

    public event Action<CrossGameCell> OnClick; 

    public void SetPlayer(int playerID)
    {
        PlayerId = playerID;
        if (playerID == -1)
        {
            _image.sprite = null;
        }
        else
        {
            _image.sprite = _shapes[playerID];
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke(this);
    }
}
