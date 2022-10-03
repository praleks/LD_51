using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUpSystem : MonoBehaviour
{
    public GameComponent game;

    public TMPro.TextMeshProUGUI levelText;

    private void OnEnable()
    {
        GameComponent.OnGameStart += OnGameStart;
        GameComponent.OnCardClick += OnCardClick;
    }

    private void OnDisable()
    {
        GameComponent.OnGameStart -= OnGameStart;
        GameComponent.OnCardClick -= OnCardClick;
    }

    private void OnGameStart()
    {
        UpdatePlayerLevelText();
    }

    private void UpdatePlayerLevelText()
    {
        levelText.text = "Player Level: " + game.playerLevel;
    }

    private void OnCardClick(CardComponent card)
    {
        if(card.cardType == CardType.LevelUp)
        {
            game.playerLevel++;
            UpdatePlayerLevelText();
            GameComponent.OnLevelUp?.Invoke();
        }
    }
}
