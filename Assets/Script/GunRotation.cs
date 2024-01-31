using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    [SerializeField] private Vector3 root;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GunController gunController;
    void Update()
    {
        GetPosition();
        GunRotating();
    }
    private void GetPosition()
    {
        if (gunController.isManualAim)
        {
            root = InputManager.Instance.mouseWorldPos;
        }
        else
        {
            root = playerController.nearestEnemy.position;
        }
    }
    private void GunRotating()
    {
        Vector3 distance = root - transform.parent.position;
        distance.Normalize();
        float gunRotationZ = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, gunRotationZ - 90);
    }
}
