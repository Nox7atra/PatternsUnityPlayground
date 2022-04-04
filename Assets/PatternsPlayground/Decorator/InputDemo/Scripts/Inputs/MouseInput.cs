using UnityEngine;

public class MouseInput : MonoBehaviour, IInputDecorator
{

    private Vector3 _motionVector;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _motionVector = Vector3.zero;
        if (Input.GetMouseButton(0))
        {
            var mousePos = Input.mousePosition;
            mousePos.z = -_camera.transform.position.z;
            _motionVector += (_camera.ScreenToWorldPoint(mousePos) - transform.position);
        }
    }

    public Vector3 GetMotionVector()
    {
        return _motionVector.normalized;
    }
}
