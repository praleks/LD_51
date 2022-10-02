using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    //public UnitComponent playerPrefab;
    public Transform[] playerStart;
    public EnemySpawnComponent[] enemyStart;

    public List<UnitComponent> enemies;
    public List<UnitComponent> players;

    public List<BulletComponent> bullets;
    public List<CardComponent> cards;
}
