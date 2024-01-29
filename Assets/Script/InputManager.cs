using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }
    [SerializeField] public Vector3 mouseWorldPos;
    [SerializeField] private Camera camera;
    [SerializeField] public bool isClick = false;
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        GetWorldPos();
        IsClick();
    }
    public void GetWorldPos(){
        mouseWorldPos=camera.ScreenToWorldPoint(Input.mousePosition);
    }
    public void IsClick(){
        isClick = Input.GetButtonDown("Fire1");
    }
}
