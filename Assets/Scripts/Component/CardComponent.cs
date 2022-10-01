using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Unit,
    Wepon,
    Buff,
}

public class CardComponent : MonoBehaviour
{
    public CardType cardType;

    public void OnClick()
    {
        GameComponent.OnCardClick?.Invoke(this);
    }
}
