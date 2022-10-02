using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSystem : MonoBehaviour
{
    public GameComponent game;
    public LevelComponent level;

    private void OnEnable()
    {
        GameComponent.OnSpawnPlayer += OnSpawnPlayer;
        GameComponent.OnCardClick += OnCardClick;
    }

    private void OnCardClick(CardComponent card)
    {
        if(card.cardType == CardType.Weapon)
        {
            game.playerWeapon = card.weapon;

            foreach(var player in level.players)
            {
                ChangeWeapon(player, game.playerWeapon);
            }
        }
    }

    private void OnSpawnPlayer(UnitComponent player)
    {
        ChangeWeapon(player, game.playerWeapon);
    }

    public void ChangeWeapon(UnitComponent player, WeaponComponent newWeapon)
    {
        Destroy(player.weapon.gameObject);
        player.weapon = Instantiate(newWeapon, player.weaponSlot, false);
    }
}
