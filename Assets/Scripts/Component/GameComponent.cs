using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent : MonoBehaviour
{
    public CardComponent[] cardPrefabs;

    public float timer = 10f;
    public int playerDamage = 1;
    public int playerMaxHealth = 50;
    public float playerReload = 1;
    public float playerAccuracy = 1;
    public float playerCrit = 1;
    public float playerRange = 1;
    public WeaponComponent playerWeapon;
    public static Action<UnitComponent, UnitComponent> OnUnitShot;
    public static Action<CardComponent> OnCardClick;
    public static Action OnTimer;
    public static Action<UnitComponent> OnSpawnPlayer;

    public static Action OnGameStart;
}
