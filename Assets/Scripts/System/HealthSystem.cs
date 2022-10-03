using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private void OnEnable()
    {
        GameComponent.OnChangeLivesUnit += OnChangeLivesUnit;
    }

    private void OnChangeLivesUnit(UnitComponent unit)
    {
        unit.hpBar.localScale = new Vector3(((float)unit.lives) / unit.maxLives, 1f, 1f);
    }
}
