using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField][Range(0, 1)] private float _spriteAlphaOnEnter = 0.5f;
    
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _spriteRenderer.color = new Color(255, 255, 255, _spriteAlphaOnEnter); 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _spriteRenderer.color = Color.white;
    }
}
