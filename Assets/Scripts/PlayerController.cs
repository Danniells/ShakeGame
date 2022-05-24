using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20;
    public float jumpForce;
    private bool isOnGround;
    private float zBound = 25;
    private float xBound = 25;

    Rigidbody playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        MovePlayer();
        Jump();
        ConstrainPlayerPosition();

    }

    private void OnCollisionEnter(Collision other){
        isOnGround = true; //prevent double jump
        if(other.gameObject.CompareTag("Enemy")){
            Debug.Log("Player has collides with enemy.");
        }
        
    } 

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PowerUp")){
            Destroy(other.gameObject);
            Debug.Log("Player has pick the power up.");
        }
    }

    void MovePlayer(){ //moves the player based on arrow key input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        playerRB.AddForce(Vector3.forward * speed * vertical);
        playerRB.AddForce(Vector3.right * speed * horizontal);

    }
    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround) { //condition to not double jump
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

    }

    void ConstrainPlayerPosition(){ //prevent the player from leaving the edge of the screen
        if(transform.position.z < -zBound)  transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        if(transform.position.x > xBound)   transform.position = new Vector3(xBound, transform.position.y, transform.position.z);

    }
    
}
