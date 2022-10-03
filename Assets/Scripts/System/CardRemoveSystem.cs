using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardRemoveSystem : MonoBehaviour
{
    public LevelComponent level;
    private void OnEnable()
    {
        GameComponent.OnCardClick += OnCardClick;
    }
    private void OnDisable()
    {
        GameComponent.OnCardClick -= OnCardClick;
    }

    private void OnCardClick(CardComponent card)
    {
        level.cards.Remove(card);
        card.GetComponentInChildren<Button>().interactable = false;
        Destroy(card.gameObject, 0.1f);
    }
}
