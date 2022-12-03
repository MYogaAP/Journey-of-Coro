using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingRandom : MonoBehaviour
{
    [SerializeField] private Sprite[] sprite;
    void Start()
    {
        int randomPick = Random.Range(0, 9);
        gameObject.GetComponent<Image>().sprite = sprite[randomPick];
    }
}
