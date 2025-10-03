using UnityEngine;
//written by Eli, following a tutorial, slightly modified to fit the skydome used.
public class DayCycle : MonoBehaviour
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
