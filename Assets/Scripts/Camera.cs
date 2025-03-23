using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    private void Update() {
        if(target.position.y > transform.position.y){
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
