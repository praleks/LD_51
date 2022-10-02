using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthSystem : MonoBehaviour
{
    public GameComponent game;

    public TMPro.TextMeshProUGUI maxHealthText;

    private void OnEnable()
    {
        GameComponent.OnGameStart += OnGameStart;
        GameComponent.OnCardClick += OnCardClick;
    }

    private void OnGameStart()
    {
        UpdateMaxHeathText();
    }

    private void OnCardClick(CardComponent card)
    {
        if(card.cardType == CardType.MaxHealth)
        {
            game.playerMaxHealth += card.value;
            UpdateMaxHeathText();
        }
    }

    private void UpdateMaxHeathText()
    {
        maxHealthText.text = "Max Health: " + game.playerMaxHealth;
    }
}
