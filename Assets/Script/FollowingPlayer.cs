using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPlayer : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] bool isFollowing;
    private void Update()
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        if (isFollowing)
        {
            Vector3 position = playerPosition.position;
            position.z = -10;
            transform.position = position;
        }
    }
}
