using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private GameObject information;
    [SerializeField] private AudioSource quack;
    private int currentScore;
    private float wait;

    private void Start()
    {
        currentScore = TrackItem.ItemScore;
    }

    private void Update()
    {
        if(currentScore != TrackItem.ItemScore)
        {
            currentScore = TrackItem.ItemScore;
            information.SetActive(true);
            wait = 3;
        }

        if(wait >= 0)
        {
            wait -= Time.deltaTime;
        } else
        {
            information.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            quack.Play();
            Destroy(other.gameObject);
            TrackItem.ItemScore += 1;
        }
    }
}
