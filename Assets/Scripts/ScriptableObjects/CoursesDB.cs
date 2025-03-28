using UnityEngine;

[CreateAssetMenu(fileName = "CourseSegments", menuName = "Scriptable Objects/CourseSegments")]
public class CoursesDB : ScriptableObject
{
    public GameObject[] easyCourses;
    public GameObject[] mediumCourses;
    public GameObject[] hardCourses;
    public GameObject[] rareCourses;

    public GameObject getRandCourse()
    {
        float rand = Random.Range(0f, 1f);
        if (rand < 0.5f) return easyCourses[Random.Range(0, easyCourses.Length)];
        if (rand < 0.8f) return mediumCourses[Random.Range(0, mediumCourses.Length)];
        if (rand < 0.95f) return hardCourses[Random.Range(0, hardCourses.Length)];
        return rareCourses[Random.Range(0, rareCourses.Length)];
    }
}
