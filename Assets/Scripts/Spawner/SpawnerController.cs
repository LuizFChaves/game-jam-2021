using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour{

    public enum SpawnState { spawning, waiting }

    [System.Serializable]
    public class Wave {
        public GameObject[] enemies;
        public int count = 1;
        public float RPM = 1f;
        public float timeToNextWave = 0f;
    }
    [SerializeField]
    public Wave[] waves;

    int nextWave = 0;
    float timeBetweenWaves = 5f;
    float waveCountdown;

    bool ended = false;
    SpawnState state = SpawnState.waiting;

    Spawner[] spawners = new Spawner[3];

    IEnumerator SpawnWave(Wave _wave) {
        state = SpawnState.spawning;

        for(int i=0; i < _wave.count; i++) {
            Spawner spawner = spawners[Random.Range(0, spawners.Length)];
            spawner.createEnemy(_wave.enemies[Random.Range(0, _wave.enemies.Length)]);
            yield return new WaitForSeconds(60 / _wave.RPM); 
        }
        nextWave++;
        state = SpawnState.waiting;
        yield break;
    }

    void Start() {
        spawners[0] = this.gameObject.transform.GetChild(0).GetComponent<Spawner>();
        spawners[1] = this.gameObject.transform.GetChild(1).GetComponent<Spawner>();
        spawners[2] = this.gameObject.transform.GetChild(2).GetComponent<Spawner>();

        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update() {
        if (!ended) {

            if(waveCountdown <= 0) {
                if(state == SpawnState.waiting) {
                    if(! (nextWave >= waves.Length)) {
                        StartCoroutine(SpawnWave(waves[nextWave]));
                    }
                }
            } else {
                waveCountdown -= Time.deltaTime;
            }
        }
    }
}
