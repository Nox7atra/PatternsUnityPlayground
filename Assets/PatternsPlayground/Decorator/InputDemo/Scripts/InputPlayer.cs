
using System.Linq;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    [SerializeField] private float _Speed = 1;
    private IInputDecorator[] _inputs;
    private void Start()
    {
        _inputs = GetComponents<IInputDecorator>();
    }

    private void Update()
    {
        var input = _inputs.FirstOrDefault(x => x.GetMotionVector().magnitude > 0);
        if (input != null)
        {
            transform.position += input.GetMotionVector() * _Speed * Time.deltaTime;
        }
    }
}
