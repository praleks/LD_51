using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Unit,
    Heal,
    LevelUp,
    //Weapon,
    //Damage,
    //MaxHealth,
    //ReloadFaster,
    //Accuracy,
    //Crit,
    //Range,
}

public class CardComponent : MonoBehaviour
{
    public CardType cardType;
    public WeaponComponent weapon;
    public int value;

    public bool canSelectEmptySpawn = true;
    public bool canSelectFullSpawn = true;

    public void OnClick()
    {
        GameComponent.OnCardClick?.Invoke(this);
    }

    public void OnDrag()
    {
        GameComponent.OnCardDrag?.Invoke(this);
    }
}
