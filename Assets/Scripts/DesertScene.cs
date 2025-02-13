using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertScene : MonoBehaviour
{
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
    private int objGenerated;

    [Header("Color of forest")]
    [SerializeField] Color[] colorsOfForest;

    // Start is called before the first frame update
    void Start()
    {
        CreatePlane();
        CreateForestParent();
        CreateRandomForest();
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
        if (numObjInForest == 0)
        {
            numObjInForest = 10;
        }

        if (xOffsetCenter == 0)
        {
            xOffsetCenter = 5;
        }

        if (zOffsetCenter == 0)
        {
            zOffsetCenter = 5;
        }

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
            _generated.transform.parent = forestParent.transform;
            _generated.GetComponent<MeshRenderer>().material.color = colorsOfForest[Random.Range(0, colorsOfForest.Length)];
        }
    }
}
