using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] Transform bullet;
    [SerializeField] Transform gun;

    // Update is called once per frame
    void Update()
    {
        IsFire();
    }
    private void IsFire(){
        if(InputManager.Instance.isClick)
        {
            Transform bulletPrefab = BulletPool.Instance.GetInstantiateObjects();
            bulletPrefab.position=transform.position;
            bulletPrefab.rotation=transform.rotation;
            bulletPrefab.gameObject.SetActive(true);
        }
        
        //Instantiate(bullet,gun.transform.position,transform.rotation);
    }
}
