using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public Transform moveObject;

    Player player;
    // Start is called before the first frame update
    void Start(){
        player = GetComponent<Player>();
        moveObject.parent = null;
    }

    // Update is called once per frame
    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, moveObject.position, movementSpeed * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, moveObject.position) <= .05f) {


            if(Mathf.Abs(player.input.movementInput.y) == 1) {
                moveObject.position += new Vector3(0, player.input.movementInput.y*3, 0);
            }

            if (
                (moveObject.transform.position.y <= 0)
                || (moveObject.transform.position.y >= 2f * player.mainCam.orthographicSize)
            ) {
                moveObject.position -= new Vector3(0, player.input.movementInput.y * 3, 0);
            }
        }

    }
}
