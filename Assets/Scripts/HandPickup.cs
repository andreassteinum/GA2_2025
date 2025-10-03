using UnityEngine;

public class HandPickup : MonoBehaviour
{


    public Inventory inventory;
    public string targetTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == targetTag)
        {
            Transform obj = other.transform;            
            
            Debug.Log("add " + targetTag + ".");
            inventory.Add(obj.gameObject);
            obj.gameObject.SetActive(false);
            obj.position = Vector3.down * 666.0f;
            
        }
    }
}
