using UnityEngine;

public class MoveDownSimple : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
      gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();  
    }

    [Tooltip("The speed at which the object moves downward (units per second).")]
    public float speed = 5f;
    private float fallspeed=40;
    public Vector3 direction;

    void Update()
    {
         if (gameManager.fallingEror==false)
           {
        // 1. Define the direction (downward in local space)
        direction = Vector3.down;

        // 2. Calculate the distance to travel this frame:
        //    Distance = Speed * Time_Elapsed
        float distanceThisFrame = speed * Time.deltaTime;

        // 3. Move the object by applying the calculated distance
        //    Note: 'transform.Translate' moves the object relative to its own axes (local space).
        transform.Translate(direction * distanceThisFrame);
           } else
        {
            direction = Vector3.up; 
            float distanceThisFrame = fallspeed * Time.deltaTime;

        // 3. Move the object by applying the calculated distance
        //    Note: 'transform.Translate' moves the object relative to its own axes (local space).
        transform.Translate(direction * distanceThisFrame);
        }
    }

    
}