using UnityEngine;

[CreateAssetMenu(fileName = "CourseSegments", menuName = "Scriptable Objects/CourseSegments")]
public class CourseSegments : ScriptableObject
{
    public CourseSegment[] courses;
}
