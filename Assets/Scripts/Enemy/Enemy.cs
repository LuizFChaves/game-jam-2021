using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool isAlive = true;
    public float movementSpeed = 10f;
    public float health = 3f;

    void Start(){
        
    }

    public void onGetHit(float damage) {
        this.health -= damage;
    }

    void Update(){
        if(health <= 0) {
            isAlive = false;
        } else {
            transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
        }
    }
}
