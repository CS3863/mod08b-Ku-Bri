using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickStart : MonoBehaviour
    
{
    public UseData dataFloat; 

    // Start is called before the first frame update
    void Start()
    {
       transform.localScale = new Vector3(dataFloat.tempFloat, dataFloat.tempFloat, dataFloat.tempFloat);
       Debug.Log("The tempFloat from chickStart = " + dataFloat.tempFloat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
