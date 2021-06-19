using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 1f;

    Player player;
    // Start is called before the first frame update
    void Start(){
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update(){
        if (
            (player.transform.position.y <= 0 && player.input.movementInput.y <= 0)
         || (player.transform.position.y >= 2f * player.mainCam.orthographicSize && player.input.movementInput.y >= 0)
        ) {
            return;
        }


        player.controller.Move(player.input.movementInput * movementSpeed * Time.deltaTime);
    }
}
