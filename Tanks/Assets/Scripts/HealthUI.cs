using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Text _healthText;
    private PlayerTank _playerTank;

    private void Start()
    {
        _playerTank = FindObjectOfType<PlayerTank>();
        _healthText = GetComponent<Text>();
        _healthText.text = _playerTank.Health.ToString();
        _playerTank.OnDamageRecieved += UpdateHealth;
    }

    private void UpdateHealth(float currentHealth)
    {
        _healthText.text = currentHealth.ToString();
    }

    private void OnDisable()
    {
        _playerTank.OnDamageRecieved -= UpdateHealth;
    }
}
