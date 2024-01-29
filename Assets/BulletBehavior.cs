using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private static BulletBehavior instance;
    public static BulletBehavior Instance { get => instance; }
    [SerializeField] public float bulletSpeed = 10f;
    [SerializeField] private Vector3 direction = Vector3.up;
    [SerializeField] private float timeToKill = 3f;
    public delegate void FireAction();
    public static event FireAction OnFire;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        StartCoroutine(IEKillTheBullet());
    }
    private void Update()
    {
        BulletMovement();
    }
    public void BulletMovement()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }
    private void KillTheBullet()
    {
        if (OnFire != null)
        {
            OnFire();
        }
        BulletPool.Instance.SetBulletBackToPool(transform);
    }
    private IEnumerator IEKillTheBullet()
    {
        yield return new WaitForSeconds(timeToKill);
        KillTheBullet();
    }
    public void SetType(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
    }
}
