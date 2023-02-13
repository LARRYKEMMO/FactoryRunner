using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform cameraTransform;
    public List<GameObject> obstaclePrefabs;
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
            var children = obstacleList[i].GetComponentsInChildren<Transform>();
            //skip the first element: the first element if the transfor of the obstacle prefab
            for (int j = children.Length - 1; j >= 0; j--)
            {
                if (children[j].position.z < cameraTransform.position.z)
                    Destroy(children[j].gameObject);
            }
            if (obstacleList[i].transform.childCount <= 0)
            {
                Destroy(obstacleList[i].gameObject);
                obstacleList.RemoveAt(i);
            }
        }
    }
    void spawn()
    {
        if (delay > 0)
            return;
       
        int randomObstacle = Random.Range(0, obstaclePrefabs.Count);
        obstacleList.Add(Instantiate(obstaclePrefabs[randomObstacle], spawnPoint.position, Quaternion.identity));
        Debug.Log(obstacleList[obstacleList.Count - 1].transform.position.z);
        obstacleList[obstacleList.Count - 1].transform.SetParent(this.transform);
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
            var children = obstacleList[i].GetComponentsInChildren<Transform>();
            for (int j = children.Length - 1; j > 0; j--)
            {
                children[j].GetComponent<Rigidbody>().AddForce(0, 0, -speed * Time.fixedDeltaTime);
            }

        }

    }

}
