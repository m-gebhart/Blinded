/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light light1;
    public Light light2;
    public GameObject lightCone1;
    public GameObject lightCone2;

    // Start is called before the first frame update
    void Start()
    {
        LightsOut();
    }

    public void LightsOut()
    {
        lightCone1.SetActive(false);
        lightCone2.SetActive(false);
    }

    public void LightsOn()
    {
        lightCone1.SetActive(true);
        lightCone2.SetActive(true);
    }
}
