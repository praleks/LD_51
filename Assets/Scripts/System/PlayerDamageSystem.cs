using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSystem : MonoBehaviour
{
    public GameComponent game;
    public TMPro.TextMeshProUGUI damageText;

    private void OnEnable()
    {
        GameComponent.OnCardClick += OnCardClick;
        GameComponent.OnGameStart += OnGameStart;
    }

    private void OnGameStart()
    {
        UpdatePlayerDamage();
    }

    private void OnCardClick(CardComponent card)
    {
        /*if (card.cardType == CardType.Damage)
        {
            game.playerDamage += card.value;
            UpdatePlayerDamage();
        }*/
        if(card.cardType == CardType.Heal)
        {
            game.selectedSpawn.player.lives = game.selectedSpawn.player.maxLives;
            GameComponent.OnChangeLivesUnit?.Invoke(game.selectedSpawn.player);
        }
    }

    private void UpdatePlayerDamage()
    {
        //damageText.text = "Damage: " + game.playerDamage;
    }
}
