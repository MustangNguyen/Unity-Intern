using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class Fire : MonoBehaviour
{
    [SerializeField] private GunController gunController;
    [SerializeField] private bool isFire = false;
    [SerializeField] private float attackInterval = 0.5f;

    void Start(){
        AutoFire();
    }
    void FixedUpdate()
    {
        ManualFire();
    }
    private void CreateBullet()
    {
        Transform bulletPrefab = BulletPool.Instance.GetInstantiateObjects();
        Transform bulletType = gunController.ChangeBulletTypeByNumber();
        bulletPrefab.GetComponent<BulletBehavior>().SetType(bulletType.GetComponent<BulletBehavior>());
        bulletPrefab.position = transform.position;
        bulletPrefab.rotation = transform.rotation;
        bulletPrefab.gameObject.SetActive(true);
    }
    private void ManualFire()
    {
        if (gunController.isManualAim)
        {
            if (InputManager.Instance.isClick)
            {
                CreateBullet();
            }
        }
    }
    private void AutoFire(){
        if(gunController.isAutoAimByDistance)
            InvokeRepeating("CreateBullet",0f,attackInterval);
    }
}
