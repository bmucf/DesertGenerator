using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Pyramid : MonoBehaviour
{
    [SerializeField] private int width;
    private int length;
    private int height;

    private float verticalSpace = 1.5f;
    private float horizontalSpace = 1.5f;
    private float baseX = 10;

    private Vector3 blockPos;
    private GameObject pyramidParent;


    private void Start()
    {
        CreatePyramid();
    }

    void CreatePyramid()
    {
        blockPos = new Vector3(baseX, verticalSpace, 0);
        pyramidParent = new GameObject();
        pyramidParent.name = "Pyramid Parent";
        GameObject _generatedBlock;

        #region CheckDefaults
        if(width == 0)
        {
            width = 5;
        }

        #endregion

        length = width;
        height = width;


        for(int n = 0; n < height; n++) //Up
        {
            for (int i = 0; i < width; i++) //left to right
            {
                for (int j = 0; j < length; j++) //front to back
                {
                    _generatedBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    _generatedBlock.transform.position = blockPos;
                    _generatedBlock.transform.parent = pyramidParent.transform;

                    blockPos += new Vector3(0, 0, horizontalSpace);
                }

                blockPos += new Vector3(horizontalSpace, 0, -blockPos.z);
                
            }
            baseX++;
            blockPos += new Vector3(-5, verticalSpace, 0);
            Debug.Log(blockPos.x);
            width--;
            length--;
        }
       /* for (int i = 0; i < width; i++) //left to right
        {
            for(int j = 0; j < length; j++) //front to back
            {
                _generatedBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                _generatedBlock.transform.position = blockPos;
                _generatedBlock.transform.parent = pyramidParent.transform;

                blockPos += new Vector3(0, 0, horizontalSpace);
            }

            blockPos += new Vector3(horizontalSpace, verticalSpace, -blockPos.z);
            width--;
            length--;
        }*/


        /*for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < length; j++)
            {
                _generatedBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                _generatedBlock.transform.position = blockPos;

                blockPos = new Vector3()
            }
        }*/


    }
}
