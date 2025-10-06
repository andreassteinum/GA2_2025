using UnityEngine;
//written by Eli, following a tutorial, slightly modified to fit the skydome used.
//https://devsourcehub.com/how-to-create-a-day-and-night-cycle-in-unity/

public class DayCycle : MonoBehaviour
{
    public float dayDuration = 120f; //The duration of a full day in seconds.
    private float rotationSpeed;
    public Gradient ambientColors;
    private Light sun;

    void Start()
    {
        //Calculate the rotation speed based on day duration.
        rotationSpeed = 360f / dayDuration;
        sun = GetComponent<Light>();
    }

    void Update()
    {
        //Rotating the sun as time passes.
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);

        //Adjusting ambient lighting. No idea if this actually works, I can't tell; but want to keep it just in case!
        float timeFactor = Mathf.InverseLerp(-90, 90, transform.eulerAngles.x);
        RenderSettings.ambientLight = ambientColors.Evaluate(timeFactor);
    }
}
