using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        CheckLevel();
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
