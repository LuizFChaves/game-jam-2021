using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour
{
    public GameObject spear;
    public float spearSpeed;
    public float spearDamage = 1f;

    private void OnBecameInvisible() {
        Destroy(spear);
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        if (enemy) {
            enemy.onGetHit(spearDamage);
        }
        
    }
    void Update() {
        transform.Translate(new Vector3(spearSpeed * Time.deltaTime, 0, 0));
    }
}
