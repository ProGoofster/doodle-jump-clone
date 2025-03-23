using UnityEngine;

public class PlatformBreak : MonoBehaviour {
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            this.gameObject.SetActive(false);
            Debug.Log("Platform Broken");
        }
    }
}
