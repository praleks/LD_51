using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    public BulletComponent bulletPrefab;
    public float cooldown = 0f;
    public float maxCooldown = 0.25f;
    public float distance = 4f;
    public Transform shotPoint;
}
