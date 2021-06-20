using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WaveLane {

    public List<GameObject> enemies = new List<GameObject>();
    public Spawner spawner;
    public WaveLane(Spawner _spawner) {
        spawner = _spawner;
    }
    public void spawnEnemies() {
        spawner.spawnEnemies(enemies);
    }
}


[System.Serializable]
public class Wave {
    /* 
     * Gambiarra temporaria (eu espero) para conseguir usar coroutine fora de um monoBehavior
     */


    public WaveLane[] waveLanes;
    public float timeToNextWave = 10f;

    public void SpawnWave() {
        foreach(WaveLane waveLane in waveLanes) {
            waveLane.spawnEnemies();
        }
    }


    public Wave(Spawner[] spawners) {
        waveLanes = new WaveLane[spawners.Length];
        for(int i = 0; i < spawners.Length; i++) {
            waveLanes[i] = new WaveLane(spawners[i]);
        }
    }

}
