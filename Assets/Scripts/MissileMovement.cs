using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    //Disparo vertical del player
    void Update(){
        rb.velocity = new Vector2(0,1) * speed;
    }
}
