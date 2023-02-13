using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private int forwardSpeed;
    [SerializeField]private int sidewardSpeed;
    private Rigidbody rb;
    private float dirX;
    private SpawnObjects obstacles;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        obstacles = FindObjectOfType<SpawnObjects>();
    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //seperate force for forward becasue I don't want velocity change
        //rb.AddForce(0, 0, forwardSpeed * Time.fixedDeltaTime);
        //move obstacles backward
        if(obstacles != null)obstacles.move(forwardSpeed);
        if(dirX != 0)
            rb.AddForce( dirX * sidewardSpeed * Time.fixedDeltaTime , 0, 0, ForceMode.VelocityChange);


        
    }
}
