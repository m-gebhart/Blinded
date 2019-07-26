/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carts : MonoBehaviour
{
    public static Vector3 cartCenter;

    void Awake()
    {
        foreach (Transform c in GetComponentInChildren<Transform>())
        {
            cartCenter += c.localPosition;
        }
        cartCenter = cartCenter / 12;        
    }
}