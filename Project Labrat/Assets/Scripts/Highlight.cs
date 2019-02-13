using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Highlight : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    UnityEvent highlightOn;
    [SerializeField]
    UnityEvent highlightOff;

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlightOn.Invoke();
    }
    public void OnPointerExit(BaseEventData eventData)
    {
        highlightOff.Invoke();
    }
}


