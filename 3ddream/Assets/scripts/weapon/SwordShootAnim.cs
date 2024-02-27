using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SwordShootAnim : MonoBehaviour
{
    Animator animator;
    public GameObject sword;
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && sword.GetComponent<Rigidbody>().isKinematic == true && hand.activeSelf)
        {
            animator.SetBool("Sword", true);
        } else
        {
            animator.SetBool("Sword", false);
        }
    }
}
