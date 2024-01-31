using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool instance;
    public static BulletPool Instance { get => instance; }
    [SerializeField] private List<Transform> bulletPool = new List<Transform>();
    [SerializeField] private Transform bullet;
    [SerializeField] private int bulletCount = 15;
    [SerializeField] private Transform bulletHolding;
    private void Awake()
    {
        instance = this;
        InstantiateObjects(bulletCount);
    }
    private void FindBulletHolding()
    {
        bulletHolding = transform.Find("Bullet Holding");
        Debug.Log(bulletHolding.gameObject.name);
    }
    private void InstantiateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Transform newGameObj = Instantiate(bullet);
            newGameObj.gameObject.SetActive(false);
            //FindBulletHolding();
            newGameObj.parent = bulletHolding;
            bulletPool.Add(newGameObj);
        }
    }
    public Transform GetInstantiateObjects()
    {
        Transform getBullet;
        if (bulletPool.Count != 0)
        {
            getBullet = bulletPool[0];
            bulletPool.RemoveAt(0);
            return getBullet;
        }
        else
        {
            getBullet = Instantiate(bullet);
            getBullet.parent = bulletHolding;
            bulletPool.Add(getBullet);
            return getBullet;
        }
    }
    public void SetBulletBackToPool(Transform bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletPool.Add(bullet);
    }
}
