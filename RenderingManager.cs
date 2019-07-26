/* Michael Gebhart
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingManager : MonoBehaviour
{
    public float checkFrequency, delayToProcess, renderDistance;
    float baseDistance;
    Camera cam;
    //all called tags declared by inspector
    public string[] tags;
    GameObject[][] renderObjects;

    void Update ()
    {
        if (Camera.main.farClipPlane == 300f)
            baseDistance = 180f;
    }

    void Start()
    {
        cam = Camera.main;
        baseDistance = cam.farClipPlane;
        renderObjects = new GameObject[tags.Length][];
        for (int tag = 0; tag < tags.Length; tag++)
            {
            //declaring each array for each tag
            renderObjects[tag] = GameObject.FindGameObjectsWithTag(tags[tag].ToString());

            //setting visibility of all objects to false
            for (int renderObject = 0; renderObject < renderObjects[tag].Length; renderObject++)
                if ((Vector3.Distance(cam.transform.position, renderObjects[tag][renderObject].transform.position) > baseDistance + renderDistance))
                    renderObjects[tag][renderObject].SetActive(false);
            }

        //Checking everyfreq seconds
        InvokeRepeating("Check", delayToProcess, checkFrequency);
    }

    void Check()
    {
        //checking whether objects are close to camera or not
        for (int tag = 0; tag < tags.Length; tag++)
        {
            for (int renderObject = 0; renderObject < renderObjects[tag].Length; renderObject++)
                if (renderObjects[tag][renderObject] != null)
                    if ((Vector3.Distance(cam.transform.position, renderObjects[tag][renderObject].transform.position) < baseDistance+ renderDistance))
                        renderObjects[tag][renderObject].SetActive(true);
                    else
                        renderObjects[tag][renderObject].SetActive(false);
        }
    }
}