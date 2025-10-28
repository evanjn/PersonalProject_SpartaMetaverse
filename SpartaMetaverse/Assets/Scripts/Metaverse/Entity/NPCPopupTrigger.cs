using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCPopupTrigger : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject popup; 
    [SerializeField] private float triggerDistance = 2f; 

    private Transform player;

    void Start()
    {
        if (popup != null) popup.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null || popup == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        
        if (distance <= triggerDistance && !popup.activeSelf)
        {
            popup.SetActive(true);
        }
    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (popup.activeSelf)
            popup.SetActive(false);
    }
}