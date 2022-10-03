using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionIndicatorSystem : MonoBehaviour
{
    public PlayerPositionIndicatorComponent indicator;
    public GameComponent game;
    public LevelComponent level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(game.dragCard != null && level.players.Count > 0)
        {
            Transform nearest = null;
            var dist = 1000f;
            foreach(var playerStart in level.playerStart)
            {
                if (playerStart.GetComponent<PlayerSpawnPointComponent>().player != null && !game.dragCard.canSelectFullSpawn) continue;
                if (playerStart.GetComponent<PlayerSpawnPointComponent>().player == null && !game.dragCard.canSelectEmptySpawn) continue;
                if (playerStart.GetComponent<PlayerSpawnPointComponent>().player != null && !game.dragCard.canSelectMaxPlayer && playerStart.GetComponent<PlayerSpawnPointComponent>().player.level == 4) continue;
                var d = (playerStart.transform.position - game.dragPosition).magnitude;
                if (d < dist)
                {
                    nearest = playerStart;
                    dist = d;
                }
            }

            indicator.gameObject.SetActive(nearest != null);
            if (nearest != null)
            {
                indicator.transform.position = nearest.transform.position;
                game.selectedSpawn = nearest.GetComponent<PlayerSpawnPointComponent>();
            }
        }
        else
        {
            indicator.gameObject.SetActive(false);
            game.selectedSpawn = null;
        }
    }
}
