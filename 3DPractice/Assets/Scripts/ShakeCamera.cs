using MilkShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public Shaker MyShaker;
    public ShakePreset ShakePreset;
    public bool shake = false;


    private void Update()
    {
        if (shake)
        {
            shake = false;
            MyShaker.Shake(ShakePreset);


        }

    }
}
