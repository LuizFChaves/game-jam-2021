using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour
{
    public AudioSource audioData;
    public GameObject spear;
    public float spearSpeed;
    public float spearDamage = 1f;
    bool hited = false;

    private void OnBecameInvisible() {
        if (!hited) {
            Destroy(spear);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if (!hited) {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            if (enemy) {
                audioData.Play(0);
                hited = true;
                spear.transform.parent = enemy.transform;
                enemy.onGetHit(spearDamage);
            }
        }
    }
    void Update() {
        if (!hited) {
            transform.Translate(new Vector3(spearSpeed * Time.deltaTime, 0, 0));
        }
    }
}
