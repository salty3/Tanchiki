using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private InputMaster _inputMaster;
    private Camera _mainCam;

    private void Awake()
    {
        _inputMaster = new InputMaster();
        _mainCam = Camera.main;
    }
    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDisable()
    {
        _inputMaster.Disable();
    }

    private void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        Vector2 mouseInput = _inputMaster.Player.Look.ReadValue<Vector2>();
        transform.position = _mainCam.ScreenToWorldPoint(mouseInput) + new Vector3(0, 0, 100f);
    }
    
    
}
