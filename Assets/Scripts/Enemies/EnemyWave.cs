using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewWaveData", menuName = "New Wave Data", order = 0)]
public class EnemyWave : ScriptableObject
{
    public float timeBetweenSpawns = 1;
    public List<GameObject> enemies;
}
