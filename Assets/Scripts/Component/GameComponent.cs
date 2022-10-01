using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent : MonoBehaviour
{
    public CardComponent[] cardPrefabs;

    public float timer = 10f;
    public int damage = 1;
    public int playerMaxHealth = 50;
    public static Action<UnitComponent, UnitComponent> OnUnitShot;
    public static Action<CardComponent> OnCardClick;
    public static Action OnTimer;
}
