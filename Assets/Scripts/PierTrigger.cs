using UnityEngine;
using UnityEngine.UI;

public class PierTrigger : MonoBehaviour
{

    Inventory inventory;
    public GameObject msgpanel;
    public Text text;

    public Transform avatar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            int gotboth = 0;


            string msg;
            inventory = other.transform.GetComponent<Inventory>();

            

            for(int i = 0; i < inventory.stuff.Length; i++)
            {
                if (inventory.stuff[i])
                {
                    if(inventory.stuff[i].tag == "FishingPole")
                    {
                        gotboth++;
                    }
                    if (inventory.stuff[i].tag == "Tacklebox")
                    {
                        gotboth++;
                    }

                }
            }

            if(gotboth >= 2)
            {
                msg = "Press F to go fishing";
                avatar.GetComponent<GoFishing>().inFishingVolume = true;
            }
            else
            {
                msg = "Get both pole and tackle to go fishing";
            }
            msgpanel.SetActive(true);
            text.text = msg;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            msgpanel.SetActive(false);
            avatar.GetComponent<GoFishing>().inFishingVolume = false;
        }
    }

}
