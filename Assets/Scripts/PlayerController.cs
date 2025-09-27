using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public float horizontalInput = 1.0f;
    public float verticalInput = 1.0f;
    
    private float xRotation = 0f;
    public float mouseSensitivity = 5.0f;
    public Transform playerCamera;
    public float forwardMoveSpeed = 10.0f;


    private Rigidbody body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        //get inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        float speedH = Input.GetAxis("Horizontal");
        float speedV = Input.GetAxis("Vertical");

        Vector3 vert = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vert = Vector3.up * 2000.0f;
        }
        
        //look around
        transform.Rotate(Vector3.up * mouseX);

        //get forward force
        Vector3 move = transform.forward * speedV * forwardMoveSpeed;

        //clamp it
        Vector3 clamped = Vector3.ClampMagnitude(move * Time.deltaTime * 500, 500);
        
        //add my own fucking gravity
        clamped += Vector3.down * 10.0f;
        
        //add the jump
        clamped += vert;

        //do it with physics WTF I hate Unity Physics!!!!
        body.AddForce(clamped);
        body.linearVelocity = Vector3.ClampMagnitude(body.linearVelocity, 10);

        //look at the avatar
        playerCamera.LookAt(transform);

    }
}
