using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InputMaster _inputMaster;
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _rotationSpeed = 1f;
    
    private void Awake()
    {
        _inputMaster = new InputMaster();
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
        float movementInput = _inputMaster.Player.Movement.ReadValue<float>();
        movementInput *= _movementSpeed * Time.deltaTime;
        transform.Translate(0, movementInput, 0, Space.Self);
        
        // TODO: Smooth move effect
        
        float rotationInput = _inputMaster.Player.Rotation.ReadValue<float>();
        rotationInput *= _rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotationInput, Space.Self);
        
        // TODO: Smooth rotation effect
    }
}
