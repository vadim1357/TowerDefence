using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private MoveEnemy wolfPrefab;
    [SerializeField] private MoveEnemy bearPrefab;
    [SerializeField] private MoveEnemy foxPrefab;

    [SerializeField] private int waveSize;

    [SerializeField] private float intervalSpawnWolfs;
    [SerializeField] private float intervalSpawnBears;
    [SerializeField] private float intervalSpawnFoxes;

    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    private Vector3 startPosition;
    
    private void Awake()
    {
        startPosition = transform.position;
    }

    private void Start()
    {
        StartCoroutine(SpawnWolfs());
        StartCoroutine(SpawnBears());
        StartCoroutine(SpawnFoxes());
    }

    private void SpawnEnemy(MoveEnemy enemyPrefab)
    {
        MoveEnemy enemy = Instantiate(enemyPrefab, startPosition, Quaternion.identity);
        enemy.SetSpawn(this);
    }

    IEnumerator SpawnWolfs()
    {
        for (int i = 0; i <= waveSize; i++)
        {
            yield return new WaitForSeconds(intervalSpawnWolfs);
            SpawnEnemy(wolfPrefab);
        }
    }
    IEnumerator SpawnBears()
    {
        for (int i = 0; i <= waveSize;i++)
        {
            yield return new WaitForSeconds(intervalSpawnBears);
            SpawnEnemy(bearPrefab);
        }
    }
    IEnumerator SpawnFoxes()
    {
        for (int i = 0; i <= waveSize; i++)
        {
            yield return new WaitForSeconds(intervalSpawnFoxes);
            SpawnEnemy(foxPrefab);
        }
    }

}
