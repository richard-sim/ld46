using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public float CooldownTime = 0.5f;
    public float ActuationAngle = 90.0f;
    public float VelocityUp = 900.0f;
    public float VelocityDown = 270.0f;
    
    enum RotationState
    {
        None,
        Up,
        Down
    }
    private RotationState _rotState = RotationState.None;

    private Vector3 _rotSpeedUp;
    private Vector3 _rotSpeedDown;
    private float _rotTotal;

    private Rigidbody _rigidbody;
    private Quaternion _origRotation;

    private float _timeSinceLastActivation;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
        _origRotation = _rigidbody.rotation;

        _timeSinceLastActivation = Time.time;
    }

    private void FixedUpdate()
    {
        if (_rotState == RotationState.Up)
        {
            _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(_rotSpeedUp * Time.deltaTime));
            _rotTotal += _rotSpeedUp.x * Time.deltaTime;

            if (Mathf.Abs(_rotTotal) >= ActuationAngle)
            {
                _rotState = RotationState.Down;
                _rotTotal = 0.0f;
            }
        }
        else if (_rotState == RotationState.Down)
        {
            _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(_rotSpeedDown * Time.deltaTime));
            _rotTotal += _rotSpeedDown.x * Time.deltaTime;

            if (Mathf.Abs(_rotTotal) >= ActuationAngle)
            {
                _rotState = RotationState.None;
                _rotTotal = 0.0f;
                _rigidbody.rotation = _origRotation;
            }
        }
    }

    public void ActivateFlipper()
    {
        if ((_rotState == RotationState.None) &&
            ((Time.time - _timeSinceLastActivation) >= CooldownTime))
        {
            _timeSinceLastActivation = Time.time;
            
            _rotSpeedUp = new Vector3(VelocityUp, 0.0f, 0.0f);
            _rotSpeedDown = new Vector3(VelocityDown, 0.0f, 0.0f);
            _rotTotal = 0.0f;

            _rotState = RotationState.Up;
        }
    }
}
