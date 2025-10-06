using System.Transactions;
using UnityEngine;

public class Backpack : MonoBehaviour
{


    public Transform[] fish;
    public int curslot = 0;
    public Transform theHook;
    public GoFishing fishing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int howmany = 0;
        for(int i = 0; i < fish.Length; i++)
        {
            if (fish[i])
            {
                howmany++;
            }
        }
        if(howmany == fish.Length)
        {
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            Debug.Log("player at backpack");
            if(theHook.childCount > 0)
            { 
                addFish(theHook.GetChild(0));
            }

        }
    }

    public void addFish(Transform theFish)
    {
        theFish.parent = transform;
        theFish.localPosition = Vector3.zero;

        //theFish.gameObject.SetActive(false);

        fishing.caughtAfish = false;

        fish[curslot] = theFish;
        curslot++;

    }

}
