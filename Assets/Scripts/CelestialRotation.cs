using UnityEngine;
//written by Eli, to make the visible assets of sun and moon rotate according to the time of day. 
//perhaps only a temporary script, but this felt faster than getting at parents and children through the original script.
//I have applied this to a cube in the centre of the world, which is parent to both the sun & moon on opposite sides.
//wish I had the capacity to figure out something more complex.

public class CelestialRotation : MonoBehaviour
{
    public float dayDuration = 120f; //The duration of a full day in seconds.
    private float rotationSpeed;
    void Start()
    {
        //Calculate the rotation speed based on day duration.
        rotationSpeed = 360f / dayDuration;
    }

    void Update()
    {
        //Rotating the sun as time passes.
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }

}
