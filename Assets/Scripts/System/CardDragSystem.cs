using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDragSystem : MonoBehaviour
{
    public Camera cam;
    public GameComponent game;
    Vector3 lastPos;
    private void OnEnable()
    {
        GameComponent.OnCardDrag += OnCardDrag;
    }
    private void OnDisable()
    {
        GameComponent.OnCardDrag -= OnCardDrag;
    }

    private void OnCardDrag(CardComponent card)
    {
        if (card.isClicked) return;

        game.selectedCard = card;

        game.dragCard = Instantiate(card, card.transform.parent.parent, false);
        game.dragCard.transform.position = card.transform.position;
        game.dragCard.transform.localScale = Vector3.one * 1.2f;
        game.dragCard.GetComponentInChildren<Animator>().enabled = false;
        lastPos = Input.mousePosition;
    }

    private void Update()
    {
        if(game.dragCard != null)
        {
            if(Input.GetMouseButton(0))
            {
                var d = Input.mousePosition - lastPos;
                lastPos = Input.mousePosition;
                game.dragCard.transform.position += d;

                var pos = cam.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
                game.dragPosition = pos;
            }
            if(Input.GetMouseButtonUp(0))
            {
                if (game.selectedSpawn != null)
                {
                    game.dragCard.OnClick();
                    game.selectedCard.isClicked = true;
                    Destroy(game.selectedCard.gameObject);

                    //game.selectedSpawn = null;
                }
                else
                {
                    Destroy(game.dragCard.gameObject);
                }
                game.dragCard = null;
            }
        }
    }
}
