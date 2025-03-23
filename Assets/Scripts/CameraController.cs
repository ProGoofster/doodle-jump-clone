using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;
    public float targetWidth = 20f;
    private Camera cam;
    private BoxCollider2D deathZoneCollider;

    void Awake() {
        cam = this.GetComponent<Camera>();
        deathZoneCollider = this.GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if (target.position.y > transform.position.y) {
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPosition;
        }
        UpdateCameraSize();
    }

    private void UpdateCameraSize() {
        // Calculate the orthographic size based on the aspect ratio
        float aspectRatio = (float)cam.pixelWidth / cam.pixelHeight;
        float newOrthographicSize = targetWidth / (2f * aspectRatio);

        // Adjust the camera position to keep the bottom locked
        float sizeDifference = newOrthographicSize - cam.orthographicSize;
        transform.position = new Vector3(transform.position.x, transform.position.y + sizeDifference, transform.position.z);

        cam.orthographicSize = newOrthographicSize;

        // Move the BoxCollider2D to the bottom of the camera
        float cameraBottomY = transform.position.y - cam.orthographicSize;
        deathZoneCollider.offset = new Vector2(deathZoneCollider.offset.x, cameraBottomY - transform.position.y - 1);

    }
}
