using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOf : MonoBehaviour
{
    private float zLimit = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > zLimit)
        {
            Destroy(gameObject);
        }    
    }
}
