using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotSystem : MonoBehaviour
{
    public LevelComponent level;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var player in level.players)
        {
            if (player.weapon.cooldown > 0f)
            {
                player.weapon.cooldown -= Time.deltaTime;
            }
        }

        foreach (var player in level.players)
        {
            if (player.weapon.cooldown > 0f)
            {
                continue;
            }

            foreach (var enemy in level.enemies)
            {
                var distSQ = (player.transform.position - enemy.transform.position).magnitude;
                if (distSQ < player.weapon.distance)
                {
                    GameComponent.OnUnitShot?.Invoke(player, enemy);
                    break;
                }
            }
        }
    }
}
