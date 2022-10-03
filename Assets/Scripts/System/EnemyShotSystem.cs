using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotSystem : MonoBehaviour
{
    public LevelComponent level;

    // Update is called once per frame
    void Update()
    {
        foreach (var enemy in level.enemies)
        {
            if (enemy.weapon.cooldown > 0f)
            {
                enemy.weapon.cooldown -= Time.deltaTime;
            }
        }

        foreach (var enemy in level.enemies)
        {
            if (enemy.weapon.cooldown > 0f)
            {
                continue;
            }
            bool hasEnemy = false;
            foreach (var player in level.players)
            {
                var dist = (player.transform.position - enemy.transform.position).magnitude;
                if (dist < enemy.weapon.distance)
                {
                    hasEnemy = true;
                    GameComponent.OnUnitShot?.Invoke(enemy, player);
                    break;
                }
            }
            enemy.GetComponentInChildren<Animator>().SetBool("attack", hasEnemy);
        }
    }
}
