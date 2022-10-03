using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    public GameComponent game;
    public LevelComponent level;

    // Update is called once per frame
    void Update()
    {
        
        if(level.enemies.Count == 0)
        {
            foreach (var spawn in level.enemyStart)
            {
                var enemy = Instantiate(game.enemyPrefabs[Random.Range(0, game.playerDifficulty+1)]);
                enemy.transform.position = spawn.transform.position;
                level.enemies.Add(enemy);
            }
            game.enemyLevel++;
            if(game.enemyLevel > (game.playerDifficulty + 1) * 3 && game.playerDifficulty < game.enemyPrefabs.Length)
            {
                game.playerDifficulty++;
            }
        }
    }
}
