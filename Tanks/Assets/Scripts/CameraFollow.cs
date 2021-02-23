using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followSpeed = 1f;
    private Transform _player;
    
    private void Start()
    {
        _player = FindObjectOfType<PlayerTank>().transform;
    }

    private void Update()
    {
        if (_player)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        Vector3 cameraPosition = new Vector3(_player.position.x, _player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, cameraPosition, _followSpeed * Time.deltaTime);
    }
}
