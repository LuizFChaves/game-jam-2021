using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour{

    [SerializeField]
    public List<Wave> waves = new List<Wave>();

    int nextWaveIndex = 0;
    public float waveCountdown = 5f;

    public void createWave() {
        Spawner[] spawners = new Spawner[transform.childCount];
        for(int i=0; i< spawners.Length; i++) {
            spawners[i] = transform.GetChild(i).GetComponent<Spawner>();
        }
        waves.Add(new Wave(spawners));
    }


    // Update is called once per frame
    void Update() {
        if(waveCountdown <= 0 ) {
           if(! (nextWaveIndex >= waves.Count)) {
                Wave nextWave = waves[nextWaveIndex++];
                nextWave.SpawnWave();
                waveCountdown += nextWave.timeToNextWave;
           }
        } else {
            waveCountdown -= Time.deltaTime;
        }
   
    }
}
