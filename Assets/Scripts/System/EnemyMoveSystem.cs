using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveSystem : MonoBehaviour
{
    public LevelComponent level;

    private void Update()
    {
        foreach(var enemy in level.enemies)
        {
            foreach(var player in level.players)
            {
                var dist = (player.transform.position - enemy.transform.position).magnitude;
                if(dist < enemy.weapon.distance)
                {
                    goto end;
                }
            }
            enemy.transform.position += Vector3.left * enemy.speed * Time.deltaTime;
            end:;
        }
    }
}
