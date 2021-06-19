using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void createEnemy(GameObject enemy) {
        Instantiate(enemy, transform.position, Quaternion.Euler(0, 0, 0));
    }
}
