using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorTexture;
    [SerializeField] private Vector2 _cursorHotSpot;
    
    private void Start()
    {
        UnityEngine.Cursor.SetCursor(_cursorTexture, _cursorHotSpot, CursorMode.Auto);
    }
}
