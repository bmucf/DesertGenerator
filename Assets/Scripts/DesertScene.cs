using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class DesertScene : MonoBehaviour
{
    public int baseSize;
    public float stoneOffset;

    private int stonesRequired;

    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
        CreatePyramid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeVariables()
    {
        for (int i = baseSize; i > 0; i--)
        {
            stonesRequired = stonesRequired + (baseSize * baseSize);
            baseSize--;
        }

        Debug.Log("Total Number of Stones: " + stonesRequired);
    }

    void CreatePyramid()
    {
        GameObject pyramidParent = new GameObject("PyramidParent");

        for (int i = 0; i < 4; i++)
        {
            GameObject stone = GameObject.CreatePrimitive(PrimitiveType.Cube);
            stone.transform.parent = pyramidParent.transform;
            stone.transform.position = new Vector3(i * stoneOffset, 0, 0);
        }
    }
}
