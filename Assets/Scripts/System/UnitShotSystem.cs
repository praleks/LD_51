using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShotSystem : MonoBehaviour
{
    public LevelComponent level;
    private void OnEnable()
    {
        GameComponent.OnUnitShot += OnUnitShot;
    }
    private void OnDisable()
    {
        GameComponent.OnUnitShot -= OnUnitShot;

    }

    private void OnUnitShot(UnitComponent fromUnit, UnitComponent toUnit)
    {
        var bullet = Instantiate(fromUnit.weapon.bulletPrefab);
        level.bullets.Add(bullet);

        bullet.transform.position = fromUnit.weapon.shotPoint.position + (Vector3)(Random.insideUnitCircle * 0.015f);
        bullet.target = toUnit.targetPoint;
        bullet.targetOffset = Random.insideUnitCircle * 0.015f;
        bullet.start = bullet.transform.position;
        bullet.line.positionCount = 2;

        fromUnit.weapon.cooldown = fromUnit.weapon.maxCooldown;
    }
}
