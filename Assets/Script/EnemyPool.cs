using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPool : MonoBehaviour
{
    private static EnemyPool instance;
    public static EnemyPool Instance { get => instance; }
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private int prefabsQuanlity = 10;
    [SerializeField] private List<Transform> prefabsList = new List<Transform>();
    [SerializeField] private Transform holder;
    private void Awake()
    {
        instance = this;
        InstantiateList();
    }
    private void InstantiateList()
    {
        for (int i = 0; i < prefabsQuanlity; i++)
        {
            Transform newEnemyPrefabs = Instantiate(enemyPrefab);
            newEnemyPrefabs.gameObject.SetActive(false);
            prefabsList.Add(newEnemyPrefabs);
            newEnemyPrefabs.parent=holder;
        }
    }
    public Transform GetPrefabFromPool()
    {
        if(prefabsList.Count<=0) return null;
        Transform prefabFromPool = prefabsList[0];
        prefabsList.RemoveAt(0);
        return prefabFromPool;
    }
    public void ReturnPrefabBackToPool(Enemy prefab)
    {
        prefab.gameObject.SetActive(false);
        prefabsList.Add(prefab.transform);
    }
}
