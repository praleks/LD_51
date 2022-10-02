using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardChance
{
    public CardComponent cardPrefab;
    public int timerDropChance = 100;
}

public class GameComponent : MonoBehaviour
{
    public CardChance[] cardChances;
    public UnitComponent[] playerPrefabs;

    public float timer = 10f;
    public int playerDamage = 1;
    public int playerMaxHealth = 50;
    public float playerReload = 1;
    public float playerAccuracy = 1;
    public float playerCrit = 1;
    public float playerRange = 1;
    public int playerLevel = 0;
    public WeaponComponent playerWeapon;

    public CardComponent dragCard;
    public CardComponent selectedCard;





    public static Action<UnitComponent, UnitComponent> OnUnitShot;
    public static Action<CardComponent> OnCardClick;
    public static Action<CardComponent> OnCardDrag;
    public static Action OnTimer;
    public static Action<UnitComponent> OnSpawnPlayer;

    public static Action OnGameStart;
    public static Action OnLevelUp;
}
