using UnityEngine;

[CreateAssetMenu(fileName = "CourseSegments", menuName = "Scriptable Objects/CourseSegments")]
public class CourseSegments : ScriptableObject
{
    public CourseSegment[] easyCourses;
    public CourseSegment[] mediumCourses;
    public CourseSegment[] hardCourses;
    public CourseSegment[] rareCourses;
}
