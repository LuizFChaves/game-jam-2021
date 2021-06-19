using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Camera mainCam;
    public CharacterController controller { get; private set; }
    public InputController input { get; private set; }
    public MovementController movement { get; private set; }
    

    public bool isAttacking { get; private set; }


    private void Awake() {
        controller = GetComponent<CharacterController>();
        input = GetComponent<InputController>();
        movement = GetComponent<MovementController>();
    }

    private void Attack() {
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = input.isAttacking;
    }
}
