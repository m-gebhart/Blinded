/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivalStars : MonoBehaviour
{
    public static bool turnOff;

    void Update()
    {
        if(turnOff){
            Destroy(gameObject);
        }
    }
}
