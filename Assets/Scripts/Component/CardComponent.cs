using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Unit,
    Weapon,
    Damage,
    MaxHealth,
    Heal,
    ReloadFaster,
    Accuracy,
    Crit,
    Range,
    LevelUp,
}

public class CardComponent : MonoBehaviour
{
    public CardType cardType;
    public WeaponComponent weapon;
    public int value;

    public void OnClick()
    {
        GameComponent.OnCardClick?.Invoke(this);
    }

    public void OnDrag()
    {
        GameComponent.OnCardDrag?.Invoke(this);
    }
}
