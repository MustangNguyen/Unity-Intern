using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform bullets;
    [SerializeField] public bool isManualAim = true;
    [SerializeField]  public bool isAutoAimByDistance = false;
    [SerializeField] private List<Transform> bulletTypes = new List<Transform>();
    public Translate bulletTypeAfterChange;
    private void Start(){
        LoadComponent();
    }
    public Transform ChangeBulletTypeByNumber(){
        int bulletNumber = InputManager.Instance.numberButton;
        switch (bulletNumber){
            case 1: 
                return bulletTypes[bulletNumber-1];
            case 2: 
                return bulletTypes[bulletNumber-1];
            case 3: 
                return bulletTypes[bulletNumber-1];
            case 4: 
                return bulletTypes[bulletNumber-1];
            default:
                return bulletTypes[0];
        }
    }
    private void LoadComponent(){
        foreach(Transform prefab in bullets){
            bulletTypes.Add(prefab);
        }
    }
}
