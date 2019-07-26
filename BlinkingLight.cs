/* Michael Gebhart
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public float frequency, maxValue, delay;
    float originIntensity;
    public bool isWaiting = true, enabled = true;
    Light light;

    void Start()
    {
        light = this.GetComponent<Light>();
        originIntensity = light.intensity;
        if (originIntensity == 0)
            originIntensity++;
        StartCoroutine(SetDelay());
    }

    void FixedUpdate()
    {
        if (!isWaiting && enabled)
            light.intensity = originIntensity * (Mathf.Abs(Mathf.Sin(Time.time * frequency) * maxValue));
    }

    IEnumerator SetDelay()
    {
        yield return new WaitForSeconds(delay);
        isWaiting = false;
    }
}