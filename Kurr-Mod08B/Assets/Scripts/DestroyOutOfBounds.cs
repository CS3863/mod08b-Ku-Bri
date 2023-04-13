using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBound = 10.0f;
    private float lowerBound = -10.0f;
    private float leftBound = -20.0f;
    private float rightBound = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
}
