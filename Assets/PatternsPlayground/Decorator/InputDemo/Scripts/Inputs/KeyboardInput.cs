using UnityEngine;

public class KeyboardInput : MonoBehaviour, IInputDecorator
{
    private Vector3 _motionVector;
    private void Update()
    {
        _motionVector = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            _motionVector += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _motionVector += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _motionVector += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _motionVector += Vector3.down;
        }
    }

    public Vector3 GetMotionVector()
    {
        return _motionVector.normalized;
    }
}
