/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkLamps : MonoBehaviour
{
    public ParticleSystem one;
    bool on;

    void Awake()
    {
        one.Stop();
    }

    void Update()
    {
        if (Girls.lampsOn == true && on ==false)
        {
            on = true;
            one.Play();
        }
    }
}
