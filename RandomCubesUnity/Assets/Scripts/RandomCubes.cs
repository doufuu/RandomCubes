/****
 * Created by: Kangjie Ouyang
 * Date Created: Jan 24, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Jan 25, 2022
 * 
 * Description: Spawns multiple cube prefabs into scene.
 ****/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    /***VARIABLES***/
    public GameObject cubePrefab; //new gameobject
    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all cubes
    public float scalingFactor = 0.95f;
    public int numberOfCubes = 0;


    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiates the list


    } //end Start()

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //add to the number of cubes
        GameObject gObj = Instantiate<GameObject>(cubePrefab); //instatiate the cube

        gObj.name = "Cube" + numberOfCubes; //name property of the object

        gObj.transform.position = Random.insideUnitSphere; //random point inside a sphere radius of 1


        Color randColor = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = randColor; //assign random color to cube

        gameObjectList.Add(gObj); //add cube to list

        List<GameObject> removeList = new List<GameObject>(); //list of game objects to be removed

        foreach (GameObject goTemp in gameObjectList) 
        {
            float scale = goTemp.transform.localScale.x; //record starting scale
            scale *= scalingFactor; //set scale multiplied by scaling factor
            goTemp.transform.localScale = Vector3.one * scale; //transforms the scale
            

            if (scale <= 0.1f) 
            {
                removeList.Add(goTemp); //add to remove list
            }


        }//end foreach


        foreach (GameObject goTemp in removeList) 
        {
            gameObjectList.Remove(goTemp); //remove ffrom gameobject list
            Destroy(goTemp); //destory the object from scene

        }//end foreach (GameObject goTemp in removeList) 

    }
}
