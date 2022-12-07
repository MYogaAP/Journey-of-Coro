using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlert : MonoBehaviour
{
    private float wait;
    [SerializeField] GameObject warningText;
    // Start is called before the first frame update
    void Start()
    {
        wait = 0;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFOV eye = GetComponent<EnemyFOV>();
        if (eye.CanSeePlayer)
        {
            warningText.SetActive(true);
            wait += Time.deltaTime;
            if(wait > 0.1)
            {
                wait = 0;
                TrackEnemyAwareness.Awareness += 1;
            }
        } else
        {
            warningText.SetActive(false);
            wait = 0;
        }
    }
}
