using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffect : MonoBehaviour
{
    private Animator animator;
    private bool isSplashing;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    
    public void Splash()
    {
        if (!isSplashing)
        {
            StartCoroutine(triggerSplash());
        }
    }
    IEnumerator triggerSplash()
    {
            isSplashing = true;
            animator.SetTrigger("TriggerSplash");
            yield return new WaitForSeconds(0.6f);
            isSplashing = false;
    }
}
