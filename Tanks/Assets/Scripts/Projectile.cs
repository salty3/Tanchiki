using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _sqrMagnitudeToDestroy = 1f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddRelativeForce(new Vector2(0f, -_speed));
        StartCoroutine(DestroyIfSlow());
    }
    
    private IEnumerator DestroyIfSlow()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            bool isSlow = _rigidbody.velocity.sqrMagnitude <= _sqrMagnitudeToDestroy;
            if (isSlow)
            {
                Destroy(gameObject);
            }
        }
    }
}
