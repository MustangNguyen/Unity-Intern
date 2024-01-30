using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GunController gunController;

    void Update()
    {
        IsFire();
    }
    private void IsFire(){
        if(InputManager.Instance.isClick)
        {
            Transform bulletPrefab = BulletPool.Instance.GetInstantiateObjects();
            Transform bulletType=gunController.ChangeBulletTypeByNumber();
            bulletPrefab.GetComponent<BulletBehavior>().SetType(bulletType.GetComponent<BulletBehavior>());
            bulletPrefab.position=transform.position;
            bulletPrefab.rotation=transform.rotation;
            bulletPrefab.gameObject.SetActive(true);
        }
        //Instantiate(bullet,gun.transform.position,transform.rotation);
    }
}
