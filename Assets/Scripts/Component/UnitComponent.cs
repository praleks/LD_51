using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    public float speed = 10f;
    public WeaponComponent weapon;
    public Transform targetPoint;
    public int lives = 5;
}
