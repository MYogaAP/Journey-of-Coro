using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public gamehandler gh;

    void Start()
    {
        gh = GameObject.Find("Canvas").GetComponent<gamehandler>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            gh.coins++;
            Destroy(gameObject);
        }
    }
}
