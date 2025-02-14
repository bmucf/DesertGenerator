using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DesertScene : MonoBehaviour
{
    public int baseDimension;
    public float stoneOffset;
    public GameObject[] stones;

    private int stonesRequired;

    // Start is called before the first frame update
    void Start()
    {
        int length = baseDimension;
        int width = baseDimension;
        int height = baseDimension;

        InitializeVariables();
        CreateGround();
        CreatePyramid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeVariables()
    {


        for (int i = baseDimension; i > 0; i--)
        {
            stonesRequired = stonesRequired + (baseDimension * baseDimension);
            baseDimension--;
        }

        Debug.Log("Total Number of Stones: " + stonesRequired);
    }

    void CreateGround()
    {

    }

    void CreatePyramid()
    {
        GameObject pyramidParent = new GameObject("PyramidParent");

        for (int i = 0; i < stonesRequired; i++)
        {
            for(int x = 0; x < length)
            {

            }
            GameObject stone = GameObject.CreatePrimitive(PrimitiveType.Cube);
            stone.transform.parent = pyramidParent.transform;
            stone.transform.position = new Vector3(i * stoneOffset, 0, 0);
            for (int j = 0; j < 4; j++)
            {
                GameObject stone2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                stone2.transform.parent = pyramidParent.transform;
                stone2.transform.position = new Vector3(0, 0, i * stoneOffset);
            }
        }
    }
}
