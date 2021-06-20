using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour{
    enum SpawnerState { spawning, waiting};


    [SerializeField]
    public List<Wave> waves = new List<Wave>();

    int nextWaveIndex = 0;
    float waveCountdown = 5f;
    SpawnerState state = SpawnerState.waiting;

    public void createWave() {
        Spawner[] spawners = new Spawner[transform.childCount];
        for(int i=0; i< spawners.Length; i++) {
            spawners[i] = transform.GetChild(i).GetComponent<Spawner>();
        }
        waves.Add(new Wave(spawners));
    }
    IEnumerator spawnNextWave() {
        Wave nextWave = waves[nextWaveIndex];
        yield return StartCoroutine(nextWave.SpawnWave());
        waveCountdown = nextWave.timeToNextWave;

        state = SpawnerState.waiting;
        nextWaveIndex++;
    }

    // Update is called once per frame
    void Update() {
        if(waveCountdown <= 0 && state== SpawnerState.waiting) {
           if(! (nextWaveIndex >= waves.Count)) {
                state = SpawnerState.spawning;
                StartCoroutine(spawnNextWave());
           }
        } else {
            waveCountdown -= Time.deltaTime;
        }
   
    }
}
