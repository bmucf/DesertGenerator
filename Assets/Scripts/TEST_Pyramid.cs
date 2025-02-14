using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Pyramid : MonoBehaviour
{
    [Header("Size of pyramid")]
    [SerializeField] private int width;
    private int length;
    private int height;

    //Increments for pyramid
    private float verticalSpace = 1.5f;
    private float horizontalSpace = 1.5f;
    private float baseX = 10;
    private float baseZ = 0;
    
    //Position and parent of each block in pyramid
    private Vector3 blockPos;
    private GameObject pyramidParent;

    //Colors for pyramid
    private Color[] blockColors = new Color[8] { Color.cyan, Color.blue, Color.red, Color.green, Color.gray, Color.white, Color.yellow, Color.magenta };
    private Color chosenColor;


    private void Start()
    {
        CreatePyramid();
    }


    
    void CreatePyramid()
    {
        //Initialize values for first bloc position
        blockPos = new Vector3(baseX, verticalSpace, 0);

        //Create object for pyramid to be a child of
        pyramidParent = new GameObject();
        pyramidParent.name = "Pyramid Parent";

        //Create a variable to store the blocks as they are created
        GameObject _generatedBlock;

        //Chose color for first level of pyramid
        chosenColor = blockColors[Random.Range(0, blockColors.Length)];


        //Check if the user inputted any values for the size of the pyramid, if not, set as default
        #region CheckDefaults
        if(width == 0)
        {
            width = 6;
        }

        #endregion

        //Set length and height for pyramid based on the width
        length = width;
        height = width;

        
        for(int n = 0; n < height; n++) //Responsible for levels pf pyramid
        {
            for (int i = 0; i < width; i++) //Responsible for rows in each level of pyramid
            {
                for (int j = 0; j < length; j++) //Responsible for columns in each level of pyramid
                {
                    //Create block, set positopm, set parent, set color
                    _generatedBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    _generatedBlock.transform.position = blockPos;
                    _generatedBlock.transform.parent = pyramidParent.transform;
                    _generatedBlock.GetComponent<Renderer>().material.color = chosenColor;

                    //Move position for next block to behind this block
                    blockPos += new Vector3(0, 0, horizontalSpace);
                }

                //Move to next row of pyramid
                blockPos = new Vector3(blockPos.x + horizontalSpace, blockPos.y, baseZ);
                
            }
            
            //Set new values for x and z for first block of new level
            baseX += 0.75f;
            baseZ += 0.75f;
            blockPos = new Vector3(baseX, blockPos.y + verticalSpace, baseZ);

            //Choose new color for next level
            chosenColor = blockColors[Random.Range(0, blockColors.Length)];
            
            //Decrease area of next level
            width--;
            length--;
        }
      


    }

}
