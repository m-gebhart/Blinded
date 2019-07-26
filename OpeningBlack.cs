/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningBlack : MonoBehaviour
{
    public float blackTime = 01f;

    void Start()
    {
        StartCoroutine(DestroyBlackScreen());
    }

    IEnumerator DestroyBlackScreen()
    {
        yield return new WaitForSeconds(blackTime);
        Destroy(this.gameObject);
    }
}
