using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public GameObject player;
    private Rigidbody pRB;

    public static List<TowerController> activeEnemies = new List<TowerController>();
    public Vector3 spawnCenter = new Vector3(0, 0, 0);
    public Vector2 spawnRange = new Vector3(2, 2);
    public EnemyWave[] waves;

    public LayerMask enemyLayer;

    private int curWave = 0;
    private float curWaveTime;
    private int curEnemyIndex = 0;

    private void Start()
    {
        pRB = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (curWave < waves.Length)
        {
            if (curEnemyIndex < waves[curWave].enemies.Count)
            {
                curWaveTime += Time.deltaTime;
                while (curWaveTime >= curEnemyIndex*waves[curWave].timeBetweenSpawns) 
                {
                    if (SpawnEnemy(waves[curWave].enemies[curEnemyIndex])) 
                    {
                        curEnemyIndex++;
                    }
                    else
                    {
                        break;
                    }
                    if (curEnemyIndex >= waves[curWave].enemies.Count) 
                    {
                        break;
                    }
                }
            }
            else
            {
                if (activeEnemies.Count == 0) 
                {
                    curEnemyIndex = 0;
                    curWave++;
                    curWaveTime = 0;
                }
            }
        }
        else 
        {
            Debug.Log("Out of waves");
            if (waves.Length > 0) 
            {
                curWave--;
            }
        }
    }

    private bool SpawnEnemy(GameObject fab) 
    {
        
        Vector3 newSpawn = RSpawnPos();
        int trys = 0;
        while (Physics.OverlapBox(newSpawn, new Vector3(2, 2, 2), Quaternion.EulerAngles(Vector3.zero), enemyLayer).Length > 0)
        {
            trys++;
            if (trys >= 5) 
            {
                return false;
            }
            newSpawn = RSpawnPos();
        }
        GameObject newEnemy = Instantiate(fab);
        newEnemy.transform.position = newSpawn;
        newEnemy.GetComponentInChildren<TurretHeadTageting>().target = pRB;
        activeEnemies.Add(newEnemy.GetComponentInChildren<TowerController>());
        return true;
    }
    private Vector3 RSpawnPos() 
    {
        return spawnCenter + new Vector3(Random.Range(-spawnRange.x / 2, spawnRange.x / 2), 0, Random.Range(-spawnRange.y / 2, spawnRange.y / 2));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(spawnCenter, new Vector3(spawnRange.x, 1, spawnRange.y));
    }

}

public class TowerController : MonoBehaviour { }
