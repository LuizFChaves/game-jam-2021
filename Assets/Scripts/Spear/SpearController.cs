using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour
{
    public GameObject spear;
    public float spearSpeed;

    private void OnBecameInvisible() {
        Destroy(spear);
    }

    void Update() {
        transform.Translate(new Vector3(spearSpeed * Time.deltaTime, 0, 0));
    }
}
