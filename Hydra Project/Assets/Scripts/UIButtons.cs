using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public bool _mouseOver;
    [SerializeField] public int Select;
    [SerializeField] public GameObject[] Buttons;
    public GameObject _targetButton;
    Texture2D cursor;

    public void AssignEvent()
    {
        EventTrigger eventTrigger = Buttons[Select].gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry eventEntry = new EventTrigger.Entry();
        eventEntry.eventID = EventTriggerType.PointerEnter;
        eventEntry.callback.AddListener((data) => {OnPointerEnterDelegate((PointerEventData)data); });
        eventTrigger.triggers.Add(eventEntry);
    }

    public void OnPointerEnterDelegate(PointerEventData data)
    {
        _mouseOver = true;
    }
    
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Cursor.SetCursor (cursor1, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
       Cursor.SetCursor (null,Vector2.zero,CursorMode.Auto);
    }
}
