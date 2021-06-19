using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    public Vector3 movementInput { get; private set; }
    public bool isAttacking { get; private set; }

    void Start()
    {
        
    }

    void Update()
    {
        isAttacking = Input.GetButton("Attack");
        float verticalInput = Input.GetAxisRaw("Vertical");
        movementInput = new Vector3(0, verticalInput,  0);
    }
}
