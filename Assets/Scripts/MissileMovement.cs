using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 topRight;

    void Start(){
        topRight = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        rb = GetComponent<Rigidbody2D>();
        //Obtengo el punto de top-right
    }

    //Disparo vertical del player
    void Update(){
        rb.velocity = new Vector2(0,1) * speed;
        //Destruyo los misiles que salgan de la pantalla de juego
        if(rb.position.y > topRight.y){
            Destroy(gameObject);
        }
    }
}
