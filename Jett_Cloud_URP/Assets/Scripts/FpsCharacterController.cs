using UnityEngine;

public class FpsCharacterController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private InputHandler _inputHandler;
    private FpsCameraController _cameraController;

    private Camera _fpsCam;
    
    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        _cameraController = GetComponentInChildren<FpsCameraController>();
        _fpsCam = GetComponentInChildren<Camera>();
        _inputHandler.movementDelegate += Move;
        _inputHandler.rotationDelegate += Rotate;
    }
    
    private void Move(Vector3 dir)
    {
        transform.Translate(dir.normalized * (movementSpeed * Time.deltaTime));
    }

    private void Rotate(Vector3 dir)
    {
        transform.Rotate(new Vector3(0,dir.x ,0) * (_cameraController.MouseSensitivity * Time.deltaTime));
    }
}
