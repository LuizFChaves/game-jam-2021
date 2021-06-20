using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{

    IEnumerator createEnemies(List<GameObject> enemies) {
        foreach(GameObject enemy in enemies) {
            Instantiate(enemy, transform.position, Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(2);
        }
        yield break;
    }
    public void spawnEnemies(List<GameObject> enemies) {
        StartCoroutine(createEnemies(enemies));
    }
}
