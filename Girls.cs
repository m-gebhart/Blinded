/* Alexandru Negoescu
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girls : MonoBehaviour
{
    public Animator animator;
    public static bool lampsOn; 

    void Update()
    {
        if (lampsOn == true)
        {
            animator.SetBool("lampsOn",true);
        }
    }
}
