using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float jump = 8f;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.relativeVelocity.y <= 0f){
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb ==null) return;

            Vector2 velocity = rb.linearVelocity;
            velocity.y = jump;
            rb.linearVelocity = velocity;
        }
    }
}
