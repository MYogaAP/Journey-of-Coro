using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void scene(string scene)
    {
        Application.LoadLevel(scene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
