using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float targetWidth = 20f;
    private Camera cam;
    
    void Awake() {
        cam = this.GetComponent<Camera>();
    }

    private void Update() {
        if(target.position.y > transform.position.y){
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPosition;
        }
        UpdateCameraSize();
    }

    private void UpdateCameraSize()
    {
        // Calculate the orthographic size based on the aspect ratio
        float aspectRatio = (float) cam.pixelWidth / cam.pixelHeight;
        cam.orthographicSize = targetWidth / (2f * aspectRatio);
    }
}
