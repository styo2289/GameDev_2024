using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField] DayNightCycle nightDayCyle;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnInterval = 1.0f;

    //private bool isNight;
    private GameObject enemySpawn;

    private List<GameObject> spawnedEnemyList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        //subscribes to when its night or day
        nightDayCyle.OnEnterNightTime += IsNight;
        nightDayCyle.OnExitNightTime += IsDay;
    }


    private void IsNight(int e){

        //when night time, start spawing enemies
        StartCoroutine(SpawnEnemy());
    }

    private void IsDay(int e){

        //when day time, stop spawning enemies and destroy remaining
        StopCoroutine(SpawnEnemy());
        DestroyEnemies(spawnedEnemyList);
    }

    private IEnumerator SpawnEnemy(){

        for(int i = 0; i < 4; i++){
            enemySpawn = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawnedEnemyList.Add(enemySpawn);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void DestroyEnemies(List<GameObject> list){
        foreach(GameObject obj in list){
            Destroy(obj);
        }
    }
    
}

