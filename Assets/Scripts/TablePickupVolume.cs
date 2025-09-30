using UnityEngine;
using UnityEngine.UI;

public class TablePickupVolume : MonoBehaviour
{

    public GameObject msgpanel;
    public Text msg;
    
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
            Debug.Log("player in volume");
            msgpanel.SetActive(true);
            msg.text = "Pickup the fishing pole with your right hand, pick up some bait with your left.";

        }
    }

    private void OnTriggerExit(Collider other)
    {
        msgpanel.SetActive(false);
    }
}
