using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : SpawnPrefabs
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private float spawnRadius = 20f;
    
    private void OnEnable()
    {
        SpawnEnemy();
    }
    protected override void SpawnEnemy()
    {
        base.SpawnEnemy();
        StartCoroutine(IESpawnSchedule());

    }
    private IEnumerator IESpawnSchedule()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnMethod();
        }
    }
    private void SpawnMethod()
    {
        Transform newEnemy = EnemyPool.Instance.GetPrefabFromPool();
        if(playerPos==null||!playerPos.gameObject.activeSelf){
            Vector3 vector = new Vector3(0f,0f,0f);
            newEnemy.position = SetTargetCyclePos(spawnRadius,vector);
            newEnemy.rotation = Quaternion.identity;       
            newEnemy.gameObject.SetActive(true);
            return;
        }
        newEnemy.position = SetTargetCyclePos(spawnRadius,playerPos.transform.position);
        newEnemy.rotation = Quaternion.identity;       
        newEnemy.gameObject.SetActive(true);
    }
    protected override Vector3 SetTargetCyclePos(float spawnRadius,Vector3 playerPos)
    {
        float randomAngle = Random.value;
        float angleInDegrees = randomAngle * 360;
        float angleInRadians = Mathf.Deg2Rad * angleInDegrees;
        float spawnX = playerPos.x + spawnRadius * Mathf.Cos(angleInRadians);
        float spawnY = playerPos.y + spawnRadius * Mathf.Sin(angleInRadians);
        spawnPos = new Vector3(spawnX, spawnY, 0);
        return spawnPos;
    }
}
