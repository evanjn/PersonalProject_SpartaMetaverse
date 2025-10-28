using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupClickClose : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject popupRoot;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (popupRoot != null) popupRoot.SetActive(false);
    }
}
