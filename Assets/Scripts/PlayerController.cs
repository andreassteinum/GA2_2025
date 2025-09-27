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


        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        float speedH = Input.GetAxis("Horizontal");
        float speedV = Input.GetAxis("Vertical");


        transform.Rotate(Vector3.up * mouseX);


        Vector3 move = transform.forward * speedV * forwardMoveSpeed;

        transform.position = transform.position + move * Time.deltaTime;

        playerCamera.LookAt(transform);

    }
}
