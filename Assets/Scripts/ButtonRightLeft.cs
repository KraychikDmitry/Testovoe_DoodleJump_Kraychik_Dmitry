using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRightLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Range(-1f, 1f)]
    [SerializeField] private float direction;
    public Player player;

    public void OnPointerDown(PointerEventData eventData)
    {
        player.isButtonInput = true;
        player.horizntalMovement = direction;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.isButtonInput = false;
        player.horizntalMovement = 0f;
    }
}
