using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    public LevelComponent level;

    // Update is called once per frame
    void Update()
    {
        
        if(level.enemies.Count == 0)
        {
            foreach (var spawn in level.enemyStart)
            {
                var enemy = Instantiate(spawn.enemyPrefab);
                enemy.transform.position = spawn.transform.position;
                level.enemies.Add(enemy);
            }
        }
    }
}
