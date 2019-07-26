/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girlfriend : MonoBehaviour
{
    public Sprite color;
    SpriteRenderer rend;
       
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameManager.riddleNumber == 5)
        {
            rend.sprite = color;
        }
    }
}
