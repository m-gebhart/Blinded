/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    Light light;
    public int number;

    void Start()
    {
        light = GetComponent<Light>();
        LightsOut();
    }

    public void LightsOut()
    {
        light.intensity = 0;
    }

    public void LightsOn()
    {
        light.intensity = 1;
    }
}
