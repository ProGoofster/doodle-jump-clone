using UnityEngine;

public class PlatformBreak : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            // Check if the collision is coming from the top
            if (collision.relativeVelocity.y <= 0) {
                this.gameObject.SetActive(false);
                Debug.Log("Platform Broken");
            }
        }
    }
}
