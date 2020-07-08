using UnityEditor;
using UnityEngine;

public class FpsCameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;

    public float MouseSensitivity => mouseSensitivity;

    [SerializeField] private float rotMin;
    [SerializeField] private float rotMax;
    
    private InputHandler _inputHandler;
    private float _xRot = 0;
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _inputHandler = GetComponentInParent<InputHandler>();
        _inputHandler.rotationDelegate += Rotate;
    }

    private void Rotate(Vector3 dir)
    {
        _xRot -= dir.y * mouseSensitivity * Time.deltaTime;
        _xRot = Mathf.Clamp(_xRot, rotMin, rotMax);
        transform.localRotation = Quaternion.Euler(_xRot,0,0);
        
    }
}
