using UnityEngine;

public class MoveDownSimple : MonoBehaviour
{
    [Tooltip("The speed at which the object moves downward (units per second).")]
    public float speed = 20f;

    void Update()
    {
        // 1. Define the direction (downward in local space)
        Vector3 direction = Vector3.down; 

        // 2. Calculate the distance to travel this frame:
        //    Distance = Speed * Time_Elapsed
        float distanceThisFrame = speed * Time.deltaTime;

        // 3. Move the object by applying the calculated distance
        //    Note: 'transform.Translate' moves the object relative to its own axes (local space).
        transform.Translate(direction * distanceThisFrame);
    }
}