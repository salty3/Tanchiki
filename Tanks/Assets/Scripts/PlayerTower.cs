using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    //public float RotationSpeed => _rotationSpeed;
    
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private GameObject _followObject;
    
    
    private void Update()
    {
        LookAtObject();
    }
    
    private void LookAtObject()
    {
        const float addAngle = 90f;
        Vector3 vectorToTarget = _followObject.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + addAngle;
        Quaternion targerRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targerRotation, _rotationSpeed);
        
        
        
        //TODO : линии которые показывают разброс
    }

    /*private void Test()
    {
        Vector3 vectorToTarget = _followObject.transform.position - transform.position;
        Vector3 left = Quaternion.AngleAxis(-20f, Vector3.forward) * vectorToTarget;
        Vector3 right = Quaternion.AngleAxis(20f, Vector3.forward) * vectorToTarget;
        Debug.DrawRay(transform.position, vectorToTarget, Color.magenta);
        Debug.DrawRay(transform.position, left, Color.blue);
        Debug.DrawRay(transform.position, right, Color.yellow);
    }
    */
}
