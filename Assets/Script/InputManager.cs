using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }
    public int numberButton;
    [SerializeField] public Vector3 mouseWorldPos;
    [SerializeField] private Camera cam;
    [SerializeField] public bool isClick = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        GetWorldPos();
        IsClick();
        GetNumberButton();
    }
    public void GetWorldPos()
    {
        mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    public void IsClick()
    {
        isClick = Input.GetButtonDown("Fire1");
    }
    public int GetNumberButton()
    {
        try
        {
            numberButton = Convert.ToInt16(Input.inputString);
            return numberButton;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}
