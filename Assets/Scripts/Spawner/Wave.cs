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

    public void SpawnEnemies() {
        for(int i = 0; i < enemies.Count; i++) {
            spawner.createEnemy(enemies[i]);
        }
    }
}


[System.Serializable]
public class Wave  {
    public WaveLane[] waveLanes;
    public float timeToNextWave = 10f;

    public IEnumerator SpawnWave() {
        for(int i = 0; i< waveLanes.Length; i++) {
            waveLanes[i].SpawnEnemies();
        }
        
        yield break;
    }


    public Wave(Spawner[] spawners) {
        waveLanes = new WaveLane[spawners.Length];
        for(int i = 0; i < spawners.Length; i++) {
            waveLanes[i] = new WaveLane(spawners[i]);
        }
    }

}
