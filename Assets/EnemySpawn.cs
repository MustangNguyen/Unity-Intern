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
        newEnemy.position = SetTargetCyclePos(spawnRadius);
        newEnemy.rotation = Quaternion.identity;       
        newEnemy.gameObject.SetActive(true);
    }
    protected override Vector3 SetTargetCyclePos(float spawnRadius)
    {
        float randomAngle = Random.value;
        float angleInDegrees = randomAngle * 360;
        float angleInRadians = Mathf.Deg2Rad * angleInDegrees;
        float spawnX = playerPos.transform.position.x + spawnRadius * Mathf.Cos(angleInRadians);
        float spawnY = playerPos.transform.position.y + spawnRadius * Mathf.Sin(angleInRadians);
        spawnPos = new Vector3(spawnX, spawnY, 0);
        return spawnPos;
    }
}
