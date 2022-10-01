using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawSystem : MonoBehaviour
{
    public LevelComponent level;

    private void OnEnable()
    {
        GameComponent.OnCardClick += OnCardClick;
    }

    private void OnCardClick(CardComponent card)
    {
        if(card.cardType == CardType.Unit)
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        var player = Instantiate(level.playerPrefab);
        level.players.Add(player);
        player.transform.position = level.playerStart[0].position + (Vector3)Random.insideUnitCircle * .5f;
    }
}
