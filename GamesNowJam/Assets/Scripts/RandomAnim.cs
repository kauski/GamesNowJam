using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnim : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        anim = GetComponent<Animator>();

        while (true)
        {
            yield return new WaitForSeconds(5);

            anim.SetInteger("AnimIndex", Random.Range(0, 3));
            anim.SetTrigger("Animate");
            
        }
    }


}
