using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//This script is not being used at the current moment.
//This script will probably be removed before the final demo of the game.

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button thisButton;
    private Image buttonImageComponent;

    private void Awake()
    {
        if (thisButton == null)
        {
            thisButton = GameObject.FindObjectOfType<Button>();
        }

        buttonImageComponent = thisButton.GetComponent<Image>();
        buttonImageComponent.color = new Color(buttonImageComponent.color.r, buttonImageComponent.color.g, buttonImageComponent.color.b, 80);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImageComponent.color = new Color(buttonImageComponent.color.r, buttonImageComponent.color.g, buttonImageComponent.color.b, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImageComponent.color = new Color(buttonImageComponent.color.r, buttonImageComponent.color.g, buttonImageComponent.color.b, 80);

    }
}
