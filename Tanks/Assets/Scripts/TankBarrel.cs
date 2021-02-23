using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TankBarrel : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _spreadAngle = 10f;
    //[SerializeField] private float _aimAngle = 2f;
    //[SerializeField] private float _timeToAim = 2f;

    private bool _allowFire = true;
    
    private void OnFire()
    {
        if (_allowFire)
        {
            StartCoroutine(routine: Fire());
        }
    }

    public event Action<float> onFire;
    private IEnumerator Fire()
    {
        _allowFire = false;
        var projectile = Instantiate(_projectile, transform.position, ProjectileSpread());
        projectile.layer = gameObject.layer;
        onFire?.Invoke(1f / _fireRate);
        yield return new WaitForSeconds(1f / _fireRate);
        _allowFire = true;
    }

    private Quaternion ProjectileSpread()
    {
        float randomSpread = Random.Range(-_spreadAngle / 2, _spreadAngle / 2);
        Quaternion projectileSpread = transform.parent.rotation * Quaternion.AngleAxis(randomSpread, Vector3.forward);
        return projectileSpread;
    }

    //TODO: разброс уменьшается при остановке
    
}
