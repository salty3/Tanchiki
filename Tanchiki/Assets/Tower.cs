using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;
    
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
        Vector3 mouseInput = _inputMaster.Player.MousePosition.ReadValue<Vector2>();

        const float addAngle = 90f;
        var direction = mouseInput - _mainCam.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + addAngle;

        var targetRotaton = Quaternion.AngleAxis(angle, Vector3.forward);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotaton, Time.deltaTime * _rotationSpeed);

    }
}
