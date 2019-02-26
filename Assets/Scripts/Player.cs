using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private Transform missileSpawn;
    [SerializeField]
    private GameObject missile;

    private float h;
    private float minX;
    private float maxX;
    private float missileInterval;
    private float missileSpawnTime;
    private Rigidbody2D playerRb;
    private Rigidbody2D missileRb;


    void Start(){   
        playerSpeed = 5;
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.gravityScale = 0.0f;
        missileInterval = 0.8f;
    }

    private void Update() {
        //Disparo del player
        if (Input.GetKeyDown("space") && Time.time > missileSpawnTime){
            missileSpawnTime = Time.time + missileInterval;
            Instantiate(missile, missileSpawn.position, missileSpawn.rotation);
        }
    }

    private void FixedUpdate() {
        //Movimiento lateral del player
        h = Input.GetAxis("Horizontal");
        //Obtengo el punto de bottom-left
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        //Obtengo el punto de top-right
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        //Evito que el player se vaya fuera de la pantalla de juego
        playerRb.position = new Vector2(Mathf.Clamp(playerRb.position.x,min.x + 0.5f,max.x - 0.5f),playerRb.position.y);
        playerRb.velocity = new Vector2(h,0) * playerSpeed;
    }
}
