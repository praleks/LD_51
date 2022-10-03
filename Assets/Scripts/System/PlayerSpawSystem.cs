using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawSystem : MonoBehaviour
{
    public GameComponent game;
    public LevelComponent level;
    public Camera cam;

    private void OnEnable()
    {
        GameComponent.OnCardClick += OnCardClick;
        GameComponent.OnGameStart += OnGameStart;
        GameComponent.OnLevelUp += OnLevelUp;
    }

    private void OnLevelUp()
    {
        RespawnPlayers();
    }

    private void OnGameStart()
    {
    }

    private void OnCardClick(CardComponent card)
    {
        if(card.cardType == CardType.Unit)
        {
            //var pos = cam.ScreenToWorldPoint(Input.mousePosition);
            //pos.z = 0;
            SpawnPlayer(game.selectedSpawn.transform.position);
        }
    }

    private void RespawnPlayers()
    {
        if (game.selectedSpawn == null) return;

        var i = level.players.Count;
        while(i > 0)
        {
            i--;
            var oldPlayer = level.players[i];
            if (oldPlayer != game.selectedSpawn.player) continue;

            level.players.Remove(oldPlayer);

            var player = Instantiate(game.playerPrefabs[game.playerLevel]);
            level.players.Add(player);
            player.transform.position = oldPlayer.transform.position;

            GameComponent.OnSpawnPlayer?.Invoke(player);

            Destroy(oldPlayer.gameObject);
        }
    }

    private void SpawnPlayer(Vector3 pos)
    {
        var player = Instantiate(game.playerPrefabs[game.playerLevel]);
        level.players.Add(player);
        //player.transform.position = level.playerStart[0].position + (Vector3)Random.insideUnitCircle * .5f;
        player.transform.position = pos;
        game.selectedSpawn.player = player;

        GameComponent.OnSpawnPlayer?.Invoke(player);
    }
}
