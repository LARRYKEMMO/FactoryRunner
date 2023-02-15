using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private int forwardSpeed;
    [SerializeField]private int sidewardSpeed;
    [SerializeField] private int jumpForce;
    [SerializeField] private float downForce;
    [SerializeField] private int jumpheight;
    private Rigidbody rb;
    private float dirX;
    private SpawnObjects obstacles;
    private Building building;
    private bool jump;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        obstacles = FindObjectOfType<SpawnObjects>();
        building = FindObjectOfType<Building>();
    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        //seperate force for forward becasue I don't want velocity change
        //rb.AddForce(0, 0, forwardSpeed * Time.fixedDeltaTime);
        //move obstacles backward
        if(obstacles != null) obstacles.move(forwardSpeed);
        if(building != null) building.move(forwardSpeed);
        if(dirX != 0)
        {
            rb.AddForce(dirX * sidewardSpeed * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);
        if (jump && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }
        if (transform.position.y > jumpheight)
        {
            rb.AddForce(Vector3.down * (downForce), ForceMode.Impulse);
        }

    }
}
