using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject itemManager;
    [SerializeField] TrackItem track;

    private void Start()
    {
        track = itemManager.GetComponent<TrackItem>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Masuk");
        if (other.tag == "Item")
        {
            Debug.Log("Item PickUp!");
            Destroy(other.gameObject);
            track.itemScore++;
        }
    }
}
