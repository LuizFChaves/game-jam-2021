using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool isAlive = true;
    public float movementSpeed = 20f;
    public float health = 3f;
    public GameObject moveObject;
    private EnemyMoveObject enemyMove;
    public bool isMoving = false;
    public System.Guid uuid = System.Guid.NewGuid(); 
   

    void Start(){
        moveObject.transform.parent = null;
        moveObject.transform.position += new Vector3(-3, 0, 0);
    }

    private void Awake() {
        enemyMove = moveObject.GetComponent<EnemyMoveObject>();
        enemyMove.ownerUuid = uuid;
    }

    public void Walk() {
        isMoving = true;
        moveObject.transform.position += new Vector3(-1.5f, 0, 0);
    }

    public void onGetHit(float damage) {
        this.health -= damage;
    }

    void Update(){
        if(!enemyMove.isColliding) {
            transform.position = Vector3.MoveTowards(transform.position, moveObject.transform.position, movementSpeed * Time.deltaTime);
        }

        if(Vector3.Distance(transform.position, moveObject.transform.position) == 0) {
            isMoving = false;
        }

        if (health <= 0) {
            Destroy(gameObject, 0.5f);
            Destroy(moveObject, 0.5f);
            isAlive = false;
        }
    }
}
