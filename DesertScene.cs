using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertScene : MonoBehaviour
{
    //Sadie Raghunand and Brian Mosquera

    private GameObject ground;
    private float yOffset = 1;
    private GameObject forestParent;

    [Header("Location of forest")]
    [SerializeField] private float xOffsetCenter;
    [SerializeField] private float zOffsetCenter;
    private Vector3 centerOfPlane = new Vector3(0, 0, 0);
    private Vector3 centerOfForest = new Vector3(-10, 0, 0);

    [Header("Generation of forest")]
    [SerializeField] private int numObjInForest;
    [SerializeField] private float minScaleTrees;
    [SerializeField] private float maxScaleTrees;
    private int objGenerated;


    [Header("Color of forest")]
    [SerializeField] Color[] colorsOfForest;

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

    // Start is called before the first frame update
    void Start()
    {
        CreatePlane();
        CreateForestParent();
        CreateRandomForest();
        CreatePyramid();
    }

    void CreatePlane()
    {
        //Create ground object
        ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.transform.localScale = new Vector3(100, 1, 100);
    }

    void CreateForestParent()
    {
        //Create parent object for forest
        forestParent = new GameObject();
        forestParent.name = "Forest";
    }

    void CreateRandomForest()
    {

        GameObject _generated;

        //Check for change in values by user, if not inputed, set default
        #region CheckForInput
        //number of trees
        if (numObjInForest == 0)
        {
            numObjInForest = 10;
        }

        //size x of forest
        if (xOffsetCenter == 0)
        {
            xOffsetCenter = 5;
        }

        //size z of forest
        if (zOffsetCenter == 0)
        {
            zOffsetCenter = 5;
        }

        //min size of trees
        if (minScaleTrees == 0)
        {
            minScaleTrees = 0.5f;
        }

        //max size of trees
        if(maxScaleTrees == 0)
        {
            maxScaleTrees = 2;
        }

        //colors of trees
        if (colorsOfForest.Length == 0)
        {
            colorsOfForest = new Color[1];
            colorsOfForest[0] = Color.green;
        }
        #endregion


        //Run loop for generating objects in forest
        for (int i = 0; i < numObjInForest; i++)
        {
            //get integer corresponding to the object generated
            objGenerated = Random.Range(0, 3);

            //generate object type based on randomized number
            switch (objGenerated)
            {
                case 0:
                    _generated = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    break;
                case 1:
                    _generated = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    break;
                case 2:
                    _generated = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    break;
                default:
                    return;
            }

            //Randomize position of object within forest, change parent, and randomize color
            _generated.transform.position = centerOfForest + new Vector3(Random.Range(-xOffsetCenter, xOffsetCenter), yOffset, Random.Range(-zOffsetCenter, zOffsetCenter));
            _generated.transform.localScale = new Vector3(Random.Range(minScaleTrees, maxScaleTrees), Random.Range(minScaleTrees, maxScaleTrees), Random.Range(minScaleTrees, maxScaleTrees));
            _generated.transform.parent = forestParent.transform;
            _generated.GetComponent<MeshRenderer>().material.color = colorsOfForest[Random.Range(0, colorsOfForest.Length)];
        }
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
        if (width == 0)
        {
            width = 6;
        }

        #endregion

        //Set length and height for pyramid based on the width
        length = width;
        height = width;


        for (int n = 0; n < height; n++) //Responsible for levels pf pyramid
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
