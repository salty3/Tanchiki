using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloatTimerUI : MonoBehaviour
{
    [SerializeField] private float _timerStep = 0.1f;
    [SerializeField] private Vector2 _offset;
    private Text _reloadText;
    private TankBarrel _playerTankBarrel;
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
        _playerTankBarrel.onFire -= Reload;
        _inputMaster.Disable();
    }
    private void Start()
    {
        _reloadText = GetComponent<Text>();
        _reloadText.text = "0";
        _playerTankBarrel = FindObjectOfType<TankBarrel>();
        _playerTankBarrel.onFire += Reload;
    }

    private void Update()
    {
        FollowMouse();
    }

    private void Reload(float reloadTime)
    {
        StartCoroutine(ReloadRoutine(reloadTime));
    }

    private IEnumerator ReloadRoutine(float reloadTime)
    {
        while (reloadTime > 0)
        {
            reloadTime -= _timerStep;
            _reloadText.text = Math.Round(reloadTime, 1).ToString();
            yield return new WaitForSeconds(_timerStep);
        }
    }
    
    private void FollowMouse()
    {
        Vector2 mouseInput = _inputMaster.Player.Look.ReadValue<Vector2>();
        transform.position = _mainCam.ScreenToWorldPoint(mouseInput) + new Vector3(_offset.x, _offset.y, 100f);
    }
}
