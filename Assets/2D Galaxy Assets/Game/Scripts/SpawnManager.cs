using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerups;
	// Use this for initialization
	void Start () {
        StartCoroutine(EnemySpawnRoutine());
	}
	
	// Update is called once per frame

    IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-9.5f, 9.5f), 9, 0), Quaternion.identity);
        }
    }



}
