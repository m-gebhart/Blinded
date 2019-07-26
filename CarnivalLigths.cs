/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivalLigths : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        if (GameManager.riddleNumber == 3)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
