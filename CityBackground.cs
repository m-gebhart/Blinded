/* Michael Gebhart
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBackground : MonoBehaviour
{
    [Tooltip("speed of approaching darkness")]
    public float darkSpeed;
    [Tooltip("last state of darkness between 0f and 1f")]
    public float finalValue;
    SpriteRenderer renderer;
    Color tempColor;
    float colorValue = 1f;

    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        tempColor = renderer.color;
    }

    void FixedUpdate()
    {
        if (renderer.color.r > finalValue)
        {
            colorValue -= Time.deltaTime * darkSpeed;
            Color tempColor = new Vector4(colorValue, colorValue, colorValue, 1);
            renderer.color = tempColor;
        }
    }
}