using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] float threshold = 0.1f;
    [SerializeField] float deadzone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed;
    public UnityEvent onReleased;

    //Sets-up startPos and joint values at beginning of scene
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    //Checks if value of isPressed is higher or lower than 0 and calls neccessary fucntion
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1) {
            Pressed();
        }
        if (_isPressed && GetValue() - threshold <= 0) {
            Released();
        }
    }

    //Translates value of the button press to be between -1 and 1 for checking isPressed
    private float GetValue() 
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadzone) {
            value = 0;
        }

        //Locks values between -1 and 1
        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed() 
    {
        //Sets isPressed boolean and invokes onPressed unity event
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void Released() 
    {
        //Sets isPressed boolean and invokes onReleased unity event
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
