/* Michael Gebhart
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityStars : MonoBehaviour
{
    public float darkSpeed;
    public float finalValue;
    SpriteRenderer renderer;
    Color tempColor;
    float colorValue;

    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        colorValue = renderer.color.a;
        tempColor = renderer.color;
    }

    void FixedUpdate()
    {
        if (colorValue < finalValue)
        {
            colorValue += Time.deltaTime * darkSpeed;
            renderer.color = new Vector4(1, 1, 1, colorValue);
        }
    }
}