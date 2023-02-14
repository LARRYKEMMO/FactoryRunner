using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public Transform leftspawnPoint;
    public Transform rightspawnPoint;

    public Transform cameraTransform;
    public List<GameObject> obstaclePrefabs;
    public float landingForce;
    public Vector2 delayRange;


    private float delay = 0;
    private List<GameObject> obstacleList;
    void Start()
    {
        obstacleList = new List<GameObject>();
    }

    void removeOldObstacle()
    {
        //delete object out of camera scope
        for (int i = obstacleList.Count - 1; i >= 0; i--)
        {
            if (obstacleList[i].transform.position.z < cameraTransform.position.z)
            {
                Destroy(obstacleList[i].gameObject);
                obstacleList.Remove(obstacleList[i]);
            }         
           
        }
    }
    void spawn()
    {
        if (delay > 0)
            return;

        int randomObstacle = Random.Range(0, obstaclePrefabs.Count);
        var randomPos = new Vector3(Random.Range(leftspawnPoint.position.x, rightspawnPoint.position.x),leftspawnPoint.position.y, leftspawnPoint.position.z);
        obstacleList.Add(Instantiate(obstaclePrefabs[randomObstacle], randomPos, Quaternion.identity));
        obstacleList[obstacleList.Count - 1].transform.SetParent(this.transform);
        obstacleList[obstacleList.Count - 1].GetComponent<Rigidbody>().AddForce(new Vector3(0, -landingForce, 0));
        delay = Random.Range(delayRange.x, delayRange.y);

    }

    public void move(float speed)
    {   //move is being called by an outside method
        delay -= Time.deltaTime;
        removeOldObstacle();
        spawn();
        //delete object out of camera scope
        for (int i = obstacleList.Count - 1; i >= 0; i--)
        {
            obstacleList[i].GetComponent<Rigidbody>().AddForce(0, 0, -speed * Time.fixedDeltaTime);
        }

    }

}
