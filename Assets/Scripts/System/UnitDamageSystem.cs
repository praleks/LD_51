using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDamageSystem : MonoBehaviour
{
    public GameComponent game;
    public LevelComponent level;

    private void OnEnable()
    {
        GameComponent.OnUnitShot += OnUnitShot;
    }

    private void OnUnitShot(UnitComponent fromUnit, UnitComponent toUnit)
    {
        toUnit.lives -= game.playerDamage;
        if (toUnit.lives <= 0)
        {
            level.enemies.Remove(toUnit);
            level.players.Remove(toUnit);
            Destroy(toUnit.gameObject, 0.3f);      
        }
    }
}
