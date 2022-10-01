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

    private void OnTimer()
    {
        var cardPrefab = game.cardPrefabs[Random.Range(0, game.cardPrefabs.Length)];
        var card = Instantiate(cardPrefab, root, false);
        level.cards.Add(card);
    }
}
