using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveObject : MonoBehaviour{

    public bool isColliding = false;
    public System.Guid ownerUuid;

    private void OnTriggerEnter2D(Collider2D collision) {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy && enemy.uuid != ownerUuid) {
            isColliding = true;
            if (!enemy.isMoving) {
                enemy.Walk();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy) {
            isColliding = false;
        }
    }
 
}
