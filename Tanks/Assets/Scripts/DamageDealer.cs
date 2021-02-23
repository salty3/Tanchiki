using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;
    public float Damage => _damage;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
