using UnityEngine;

public class FishingTrigger : MonoBehaviour
{
    Light light;
    AudioSource audio;
    private Transform player;
    private bool isNearWater = false;
    public Transform fishingTarget;
    private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //GOOD SUSHI
        if (other.tag == "Player")
        {
            isNearWater = true;

            player = other.transform;

            //cast a ray from the player forward by some distance and see what we hit
            // Bit shift the index of the layer to get a bit mask
            int layerMask = 1 << 4; //water

            bool didHit = false;
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100, layerMask))
            {
                Debug.DrawRay(cam.transform.position, cam.transform.forward * hit.distance, Color.red);

                didHit = true;
            }
            else
            {
                didHit = false;

            }

            if (didHit )
            {
                fishingTarget.position = hit.point;
                fishingTarget.gameObject.SetActive(true);
            }
            else
            {
                fishingTarget.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            fishingTarget.gameObject.SetActive(false);
        }

        

    }

}
