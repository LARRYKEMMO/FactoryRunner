using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float speed;
    public GameObject building;
    private int buildingLength = 2000;
    private GameObject building1;
    private GameObject building2;
    void Start()
    {
        building1 = Instantiate(building, new Vector3(0,0,0), Quaternion.identity);
        building2 = Instantiate(building, new Vector3(0, 0, buildingLength), Quaternion.identity);

    }

    void Update()
    {
        //building1.transform.Translate();
    }
}
