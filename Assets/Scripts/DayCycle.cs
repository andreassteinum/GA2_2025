using UnityEngine;
//written by Eli, following a tutorial, slightly modified to fit the skydome used.
//https://devsourcehub.com/how-to-create-a-day-and-night-cycle-in-unity/

public class DayCycle : MonoBehaviour
{
    public float dayDuration = 120f; //The duration of a full day in seconds.
    private float rotationSpeed;
    public Gradient ambientColors;
    public Component sun;
    public Component celestialCenter;

    //Offsetting the main texture based on time.
    public float daySpeed = 0.06f;
    Renderer rend;


    void Start()
    {
        //Calculate the rotation speed based on day duration.
        rotationSpeed = 360f / dayDuration;
        
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        //Rotating the sun (and the moon) as time passes.
        sun.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        celestialCenter.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);

        //Changing the offset of the skydome material on x as time passes.
        //was not quite sure how to do this, reddit pointed me this way
        //https://docs.unity3d.com/ScriptReference/Material-mainTextureOffset.html
        float offset = Time.deltaTime * daySpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0); 
        //ugh it works but not in the way i want it to! why is it flickering instead of progressing infinitely?
       
        //Adjusting ambient lighting based on time of day. 
        //Can't tell if it works; but want to keep it just in case!
        float timeFactor = Mathf.InverseLerp(-90, 90, transform.eulerAngles.x);
        RenderSettings.ambientLight = ambientColors.Evaluate(timeFactor);
    }
}
