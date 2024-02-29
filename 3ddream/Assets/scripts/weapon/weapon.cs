using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject currenWeapon;
    bool canPickUp;

    public GameObject hand;

    public GameObject vinchester;
    public GameObject Stick;
    public GameObject sword;


    void Start()
    {
        hand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) Pickup();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
        
        void Pickup()
        {
            RaycastHit hit;

            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag == "Weapon")
                {
                    if (canPickUp) Drop();

                    currenWeapon = hit.transform.gameObject;
                    currenWeapon.GetComponent<Rigidbody>().isKinematic = true;
                    currenWeapon.transform.parent = transform;
                    currenWeapon.transform.localPosition = Vector3.zero;
                    currenWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                    canPickUp = true;
                    hand.SetActive(true);


                }
            }

        }
        void Drop()
        {
            currenWeapon.transform.parent = null;
            currenWeapon.GetComponent<Rigidbody>().isKinematic = false;
            canPickUp = false;
            currenWeapon = null;
            hand.SetActive(false);
        }
    }
}
