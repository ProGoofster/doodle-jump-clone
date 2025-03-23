using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed = .5f;
    public Vector3 endPos;
    private Vector3 startPos;
    void Start() {
        startPos = this.transform.localPosition;
    }
    
    void Update() {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.localPosition = Vector3.Lerp(startPos, endPos, time);
    }
}
