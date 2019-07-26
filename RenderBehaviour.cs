/* Michael Gebhart
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBehaviour : MonoBehaviour
{
    Renderer renderer;
    Camera cam;
    public bool offAtStart = true;
    [Tooltip("max distance between camera and object to render")]
    public float renderDistance;
    [Tooltip("timestamp, when the checking for distance should start,")]
    public float delayToProcess;
    public float checkFrequency = 1f;
    [HideInInspector]
    public bool visible, processing;
    public bool checking = false;

    void Awake()
    {
        cam = Camera.main;
        renderDistance += cam.farClipPlane;
        renderer = GetComponent<Renderer>();
        if (offAtStart)
            TurnOff();
        InvokeRepeating("CheckDistance", delayToProcess, checkFrequency);
    }

    void TurnOff()
    {
        renderer.enabled = false;
        visible = false;
    }

    void TurnOn()
    {
        renderer.enabled = true;
        visible = true;
    }

    void CheckDistance()
    {
        if (Vector3.Distance(cam.transform.position, transform.position) < renderDistance && !visible)
            TurnOn();
        else if (Vector3.Distance(cam.transform.position, transform.position) > renderDistance && visible)
            TurnOff();
    }
}