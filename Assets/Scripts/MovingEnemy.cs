using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingEnemy : MonoBehaviour
{
    

    Rigidbody enemyRB;
    GameObject player;

    private float yDestroy = -10;

    public float speed = 5;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    
    void Update()
    {
        Vector3 followPlayer = (player.transform.position - transform.position).normalized;

        enemyRB.AddForce(followPlayer * speed);
        if(transform.position.y < yDestroy)  Destroy(gameObject);
    }
}
