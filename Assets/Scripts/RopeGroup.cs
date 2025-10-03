using UnityEngine;

public class RopeGroup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Inventory inventory;
    public GameObject rod;
    public LineRenderer line;
    public GameObject endpoint;
    public bool hasRod = false; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!hasRod)
        {
            for (int i = 0; i < inventory.stuff.Length; i++)
            {

                if(inventory.stuff[i])
                {
                    if (rod.tag == inventory.stuff[i].tag)
                    {
                        endpoint.SetActive(true);
                        line.enabled = true;
                        rod.SetActive(true);
                        hasRod = true;
                    }
                }
                

            }

        }
        
    }
}
