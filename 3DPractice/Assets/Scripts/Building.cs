using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float speedScale = 1;
    private int buildingLength = 2000;
    public GameObject building1;
    public GameObject building2;
    void Start()
    {
        

    }

    void Update()
    {
        //building1.transform.Translate();
    }
    public void move(float speed)
    {
        Debug.Log(speed * speedScale * Time.deltaTime);
        //building1.transform.position = Vector2.MoveTowards(building1.transform.position, new Vector3(0, 0, -buildingLength), speed * speedScale * Time.deltaTime);
        //building2.transform.position = Vector2.MoveTowards(building1.transform.position, new Vector3(0, 0, -buildingLength), speed * speedScale * Time.deltaTime);

        building1.transform.position = new Vector3(0, 0, building1.transform.position.z - (speed * speedScale * Time.deltaTime));
        building2.transform.position = new Vector3(0, 0, building2.transform.position.z - (speed * speedScale * Time.deltaTime));


        if (building1.transform.position.z < -buildingLength)
        {
            building1.transform.position = new Vector3(0, 0, building2.transform.position.z + buildingLength);
        }
        if (building2.transform.position.z < -buildingLength)
        {
            building2.transform.position = new Vector3(0, 0, building1.transform.position.z + buildingLength);
        }

    }
}
