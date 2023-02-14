using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWalls : MonoBehaviour
{
    public Vector2 offset;
    public float speed;
    public Shader shader;
    public Material material;
    void Start()
    {
        //shader = GetComponent<Shader>();
        //material = GetComponent<Material>();
    }

    
    void Update()
    {
        var newOffset = new Vector2(offset.x * speed * Time.deltaTime, offset.y * speed * Time.deltaTime);
        material.mainTextureOffset = newOffset;
    }
}
