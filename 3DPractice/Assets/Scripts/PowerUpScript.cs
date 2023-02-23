using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody PowerUpBody;
    public float Increment;
    private Vector3 OriginalPosition;
    private Quaternion OriginalRotation;
    private bool Activate = false;
    private MeshRenderer Mesh;
    public Material Material;
    public Material Material2;
    public GameObject GameObject;
    private Player playerScript;

    void Start()
    {
        playerScript = FindObjectOfType<Player>();
        OriginalPosition = gameObject.transform.position;
        OriginalRotation = gameObject.transform.rotation;
        Mesh = GetComponent<MeshRenderer>();
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
        if(gameObject.transform.position.z <= -800)
        {
            gameObject.transform.position = new Vector3(Random.Range(-4, OriginalPosition.x), OriginalPosition.y, OriginalPosition.z);
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Mesh.enabled = false;
            Activate = true;
            Invoke("Reactivate", 1f);
            Activate = false;
            GameObject.GetComponent<Renderer>().material = Material;
            playerScript.DeactivateCollision();
            Invoke("DeactivateMaterial", 15f);
           
        }
    }

    public void Reactivate()
    {
        Mesh.enabled = true;
    }


    public void DeactivateMaterial()
    {
        GameObject.GetComponent<Renderer>().material = null;
        GameObject.GetComponent<Renderer>().material = Material2;
        playerScript.activateCollision();
    }

}
