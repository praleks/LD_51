using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardSpawnSystem : MonoBehaviour
{
    public RectTransform root;
    public GameComponent game;
    public LevelComponent level;

    private void OnEnable()
    {
        GameComponent.OnTimer += OnTimer;
    }
    private void OnDisable()
    {
        GameComponent.OnTimer -= OnTimer;
    }

    private void OnTimer()
    {
        StartCoroutine(DropCards());

        CheckLevel();
    }

    private IEnumerator DropCards()
    {
        for(int i = 0; i < game.cardsPerDrop; i++)
        {
            DropCard();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void DropCard()
    {
        var cardPrefab = game.cardChances[0].cardPrefab;

        var weight = 0;
        foreach (var cardChance in game.cardChances)
        {
            weight += cardChance.timerDropChance;
        }

        var weightRand = Random.Range(0, weight);
        weight = 0;
        foreach (var cardChance in game.cardChances)
        {
            weight += cardChance.timerDropChance;
            if (weight > weightRand)
            {
                cardPrefab = cardChance.cardPrefab;
                break;
            }
        }
        var card = Instantiate(cardPrefab, root, false);
        level.cards.Add(card);
    }

    private void CheckLevel()
    {
        var levelCards = 0;
        foreach (var c in level.cards)
        {
            if (c.cardType == CardType.LevelUp)
                levelCards++;
        }
        /*if (levelCards + game.playerLevel >= game.playerPrefabs.Length - 1)
        {
            foreach (var cardChance in game.cardChances)
            {
                if (cardChance.cardPrefab.cardType == CardType.LevelUp)
                {
                    cardChance.timerDropChance = 0;
                }
            }
        }*/
    }
}
