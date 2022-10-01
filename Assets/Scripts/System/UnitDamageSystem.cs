using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDamageSystem : MonoBehaviour
{
    public GameComponent game;
    public TMPro.TextMeshProUGUI damageText;
    public LevelComponent level;
    private void OnEnable()
    {
        GameComponent.OnUnitShot += OnUnitShot;
        GameComponent.OnCardClick += OnCardClick;
    }

    private void OnCardClick(CardComponent card)
    {
        if(card.cardType == CardType.Buff)
        {
            game.damage += 1;
            damageText.text = "Damage: " + game.damage;
        }
    }

    private void OnUnitShot(UnitComponent fromUnit, UnitComponent toUnit)
    {
        toUnit.lives -= game.damage;
        if (toUnit.lives <= 0)
        {
            level.enemies.Remove(toUnit);
            level.players.Remove(toUnit);
            Destroy(toUnit.gameObject, 0.3f);      
        }
    }
}
