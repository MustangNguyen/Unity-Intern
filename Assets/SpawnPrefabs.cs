using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
   [SerializeField] protected Transform spawnTarget;
   [SerializeField] protected float spawnTime = 2f;
   protected Vector3 spawnPos;
    protected virtual void SpawnEnemy(){
        
    }
    protected virtual Vector3 SetTargetCyclePos(float spawnRadius,Vector3 playerPos){
        return spawnPos;
    }
}
