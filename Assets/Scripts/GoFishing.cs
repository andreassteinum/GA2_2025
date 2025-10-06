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

    public bool inFishingVolume = false;

    public Transform allTheFish;
    public bool caughtAfish = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                 //rod                //tip  
        startp = ropeObj.GetChild(0).GetChild(0);
        endp = ropeObj.GetChild(1); //bait
    }

    // Update is called once per frame
    bool reelItIn = false;
    void Update()
    {

        if (inFishingVolume && !isCast) 
        {

            Vector2 screenCenter = new Vector2(Screen.width / 2, ((float)Screen.height) * 0.75f );
            Ray ray = fishCam.ScreenPointToRay(screenCenter);
            
            RaycastHit hit;
            int layerMask = 1 << 4; //water

            if (Physics.Raycast(ray, out hit,1000,layerMask))
            {
                
                target.position = hit.point;
            }
            else
            {
               
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
            //TODO:
            //add a fish as a child object  to endpoint zero fish Localposition
            //not here but, make a trigger on the backpack to drop the fish, add the fish as a child of packpack
            //Localposition 0 again
            //backpack has a script that counts it's child fish until enough
            if(caughtAfish == false)
            {
                caughtAfish = true;
                //catch the fish
                Transform thisFish = allTheFish.GetChild(0);
                thisFish.parent = endp;
                thisFish.localPosition = Vector3.zero;
            }


            //reel it in
            Vector3 pos1 = endp.position;
            Vector3 pos2 = startp.position;

            Vector3 flat1 = pos1;
            Vector3 flat2 = pos2;

            flat1.y = 0;
            flat2.y = 0;

            if (Vector3.Distance(flat1, flat2) > 4f)
                pos2.y = target.position.y;       //keep on surface of water



            if (Vector3.Distance(flat1, flat2) < 0.5f)
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
