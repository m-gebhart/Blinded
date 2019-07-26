/* Michael Gebhart
 * Cologne Game Lab
 * BA 2 - Narrative Project 2019 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couple : MonoBehaviour
{
    Animator animator;
    float kissingTime = 1f, transTime = 0.4f, kissingBreak = 4f;

    [FMODUnity.EventRef]
    public string coupleSoundEvent;
    FMOD.Studio.EventInstance coupleSoundState;
    bool soundPlayed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("Animation", kissingBreak, kissingBreak+(transTime*2));
    }

    void Animation()
    {
        animator.SetBool("areKissing", true);
        StartCoroutine(KissingAnim());
    }

    IEnumerator KissingAnim()
    {
        yield return new WaitForSeconds(kissingTime);
        animator.SetBool("areKissing", false);
    }
}
