using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStik : MonoBehaviour
{
    public GameObject hand;
    public GameObject Stick;
    public Animator StickAnimation;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && hand.activeSelf && Stick.GetComponent<Rigidbody>().isKinematic == true)
        {
            StickAnimation.Play("StickAnim");
        }
    }
}
