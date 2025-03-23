using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject course;
    public GameObject bounds;
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    private float moveX;
    public float jumpForce = 9f;
    public float springForce = 15f;


    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
    }

    void FixedUpdate() {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = moveX;
        rb.linearVelocity = velocity;

        bounds.transform.position = new Vector3(bounds.transform.position.x, this.transform.position.y, bounds.transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocity = rb.linearVelocity;
        // check if player is coming in from the top
        // reversed comparison because we're checking from the player
        if (collision.relativeVelocity.y >= 0) {
            if (collision.gameObject.tag == "Platform") velocity.y = jumpForce;
            if (collision.gameObject.tag == "Spring") velocity.y = springForce;
        }

        rb.linearVelocity = velocity;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "RightBound") {
            this.transform.position = new Vector3(this.transform.position.x - 10, this.transform.position.y, this.transform.position.z);
        }

        if (collision.gameObject.name == "LeftBound") {
            this.transform.position = new Vector3(this.transform.position.x + 10, this.transform.position.y, this.transform.position.z);
        }

        if (collision.gameObject.name == "Main Camera") {
            Debug.Log("Game Over");
            this.gameObject.SetActive(false);
        }
    }
}
