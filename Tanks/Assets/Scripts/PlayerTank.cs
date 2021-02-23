using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTank : MonoBehaviour
{
    [SerializeField] private float _acceleration = 10f;
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private float _health = 100f;

    public float Health => _health;

    private Rigidbody2D _rigidbody;
    private InputMaster _inputMaster;
    
    private Vector2 _moveInput;
    private float _rotateInput;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
        _moveInput = new Vector2(0, _inputMaster.Player.Move.ReadValue<float>());
        _rotateInput = _inputMaster.Player.Rotate.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        _rigidbody.AddRelativeForce(_moveInput * (_acceleration * Time.fixedDeltaTime));
        _rigidbody.AddTorque(_rotateInput * (_rotationSpeed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            ReceiveDamage(damageDealer.Damage);
        }
    }

    public event Action<float> OnDamageRecieved;
    private void ReceiveDamage(float damage)
    {
        if (damage >= _health)
        {
            Death();
        }
        else
        {
            _health -= damage;
            OnDamageRecieved?.Invoke(_health);
        }
    }

    public event Action OnDeath;
    private void Death()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
