using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputTab : MonoBehaviour
{
    EventSystem eventsystem;
    public Selectable firstInput;
    private void Start()
    {
        eventsystem = EventSystem.current;
        firstInput.Select();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            Selectable previous = eventsystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (previous == null) return;
            previous.Select();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = eventsystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next == null) return;
            next.Select();
        }
    }
}
