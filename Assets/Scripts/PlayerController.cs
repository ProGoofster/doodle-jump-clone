using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject course;
    public float moveSpeed = 10f;
    public Rigidbody2D groupRB;
    public Rigidbody2D playerRB;
    private float moveX;
    public float jumpForce = 9f;
    public float springForce = 20f;

    void Update() {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
    }

    void FixedUpdate() {
        Vector2 velocity = playerRB.linearVelocity;
        velocity.x = moveX;
        playerRB.linearVelocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocity = groupRB.linearVelocity;
        
        if(collision.gameObject.tag == "Platform") velocity.y = jumpForce;
        if(collision.gameObject.tag == "Spring") velocity.y = springForce;
        
        groupRB.linearVelocity = velocity;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "DeathZone") {
            Debug.Log("Game Over");
            this.gameObject.SetActive(false);
        }
    }
}
