using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody PowerUpBody;
    public float Increment;
    public Vector3 OriginalPosition;
    public Quaternion OriginalRotation;

    void Start()
    {
        OriginalPosition = gameObject.transform.position;
        OriginalRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 1f);
        if(gameObject.transform.rotation.y >= 360)
        { 
            gameObject.transform.rotation = OriginalRotation;
        }
        PowerUpBody.AddForce(0, 0, Increment * Time.deltaTime, ForceMode.VelocityChange);
        if(gameObject.transform.position.z < -600)
        {
            gameObject.transform.position = new Vector3(Random.Range(-4, OriginalPosition.x), OriginalPosition.y, OriginalPosition.z);
        }
    }
}
