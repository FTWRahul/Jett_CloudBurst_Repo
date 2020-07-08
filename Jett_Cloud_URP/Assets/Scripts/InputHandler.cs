using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public delegate void MovementDelegate(Vector3 dir);

    public delegate void RotationDelegate(Vector3 rotation);

    public delegate void AbilityDelegate(bool pressed, bool held, bool released);

    public AbilityDelegate abilityDelegate;
    public MovementDelegate movementDelegate;
    public RotationDelegate rotationDelegate;
    
    // Update is called once per frame
    void Update()
    {
        movementDelegate?.Invoke(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")));
        rotationDelegate?.Invoke(new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0));

        if (Input.GetKeyDown(KeyCode.C))
        {
            abilityDelegate?.Invoke(true, false, false);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            abilityDelegate?.Invoke(false, true, false);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            abilityDelegate?.Invoke(false, false, true);

        }
    }
}
