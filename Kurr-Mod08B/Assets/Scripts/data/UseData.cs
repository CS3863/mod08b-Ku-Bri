using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class UseData : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * 
  * Data used for this exercise came from https://daac.ornl.gov/cgi-bin/dsviewer.pl?ds_id=1831
  * Jacobs, N., W.R. Simpson, F. Hase, T. Blumenstock, Q. Tu, M. Frey, M.K. Dubey, and H.A. Parker. 2021. Ground-based Observations of XCO2, XCH4, and XCO, Fairbanks, AK, 2016-2019. ORNL DAAC, Oak Ridge, Tennessee, USA. https://doi.org/10.3334/ORNLDAAC/1831
    This dataset is openly shared, without restriction, in accordance with the EOSDIS Data Use Policy. 

    Remap help came from https://forum.unity.com/threads/re-map-a-number-from-one-range-to-another.119437/
  * */

    List<Dictionary<string, object>> data;

    //public GameObject myCube;//prefab
    int rowCount; //variable 

    private float startDelay = 2.0f;
    private float timeInterval = 0.25f;

    public object tempObj;
    public float tempFloat;

    float inputMin = 663.95f;
    float min = 1.0f;
    float inputMax = 2628.7f;
    float max = 360.0f;

    public GameObject[] animalPrefabs;


    void Awake()
    {
        this.transform.Rotate(0, 0, 0);
        Debug.Log("The initial rotation of spawner is " + this.transform.rotation);

        data = CSVReader.Read("Dataxhdo");//udata is the name of the csv file 

        for (var i = 0; i < data.Count; i++)
        {
            print("xhdo " + data[i]["xhdo"] + " ");
        }
        rowCount = 0;

    }//end Awake()

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnObject", startDelay, timeInterval);

    }//end Start()


    void SpawnObject()
    {
        tempObj = (data[rowCount]["xhdo"]);
        tempFloat = System.Convert.ToSingle(tempObj);
        Debug.Log("The tempFloat from UserData = " + tempFloat);
        //tempFloat = tempFloat - 360;
        tempFloat = Remap(tempFloat, inputMin, inputMax, min, max);

        this.transform.Rotate(0, tempFloat, 0);

        int animalIndex = 0; //Random.Range(0, animalPrefabs.Length); KEEPING ARRAY FOR POTENTIAL CHANGES IN FUTURE
        Vector3 spawnPos = new Vector3(0, 0, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, /*animalPrefabs[animalIndex].*/this.transform.rotation);

        rowCount++;

        Debug.Log("The Remapped tempFloat = " + tempFloat);
        Debug.Log("The rotation of spawner is " + this.transform.rotation);
        Debug.Log("Count = " + rowCount);
      
        Reset(tempFloat);

    }

    float Remap(float input, float inputMin, float inputMax, float min, float max)
    {
        return min + (input - inputMin) * (max - min) / (inputMax - inputMin);
    }

    private void Reset(float tempFloat)
    {
        this.transform.Rotate(0, -tempFloat, 0);
        Debug.Log("The RESET rotation of spawner is " + this.transform.rotation);
    }

}

