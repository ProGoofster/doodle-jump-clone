using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class CourseGenerator : MonoBehaviour {
    public CoursesDB courses;
    public GameObject previous = null;
    private bool generated = false;
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && !generated) {
            Debug.Log("Generate next segment");
            GameObject next = Instantiate(courses.getRandCourse(), this.transform.parent);
            next.GetComponent<CourseGenerator>().previous = this.gameObject;
            next.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 20, this.transform.position.z);
            generated = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && previous != null && previous.GetComponent<CourseGenerator>().previous != null) {
            Destroy(previous.GetComponent<CourseGenerator>().previous);
        }
    }

    public bool GetCollided(){
        return generated;
    }
}
