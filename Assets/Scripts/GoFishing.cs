using GogoGaga.OptimizedRopesAndCables;
using System.Net;
using UnityEngine;

public class GoFishing : MonoBehaviour
{

    public Transform ropeObj;
    public Camera fishCam;
    public bool isCast = false;

    public Transform endp;
    public Transform startp;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                 //rod                //hook  
        startp = ropeObj.GetChild(0).GetChild(0);
        endp = ropeObj.GetChild(1);
    }

    // Update is called once per frame
    bool reelItIn = false;
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Ray ray = fishCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << 4; //water

            if (Physics.Raycast(ray, out hit,1000,layerMask))
            {
                Debug.Log("Mouse clicked on: " + hit.collider.name + " at world position: " + hit.point);
                // You can add further logic here, e.g., interact with the hit object


                target.position = hit.point;
            }
            else
            {
                Debug.Log("Mouse clicked, but no object was hit by the ray.");
            }
        }




        if (Input.GetKeyDown(KeyCode.F))
        {
            ropeObj.gameObject.SetActive(true);
            
            BallGravity ballG = endp.GetComponent<BallGravity>();
            CannonBall ball = endp.GetComponent<CannonBall>();

            if (!isCast)
            {
                
                //Vector3 fwd = fishCam.transform.forward;
                //body.impulse = (fwd * 10.0f + Vector3.up * 30.0f);
                endp.LookAt(target);
                startp.LookAt(target);

                endp.position = startp.position ;
               

                endp.parent = null;
                
                ballG.enabled = true;
                ballG.reset();
                
                ballG.impulse = ball.fire(startp.position, target.position, 45 );
                
                isCast = true;

            }
            else
            {
                reelItIn = true;
            }

        }

        if(reelItIn)
        {
                      

            //reel it in
            Vector3 pos1 = endp.position;
            Vector3 pos2 = startp.position;

            if (Vector3.Distance(pos1, pos2) < 2f)
            {
                //reparent
                endp.parent = ropeObj;
                //allow to cast again
                isCast = false;
                reelItIn = false;
                //ropeObj.gameObject.SetActive(false);
                return;
            }

            endp.position = Vector3.Lerp(pos1, pos2, Time.deltaTime);


        }

    }
}
