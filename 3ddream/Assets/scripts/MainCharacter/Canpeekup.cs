using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEditor.Progress;


public class Weapon : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject currenWeapon;
    bool canPickUp;

    public GameObject hand;
    

    public GameObject aim;
    

    public GameObject vinchester;
    public GameObject Stick;
    public GameObject Sword;

    


    void Start()
    {
        hand.SetActive(false);
        aim.SetActive(false);
      

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) Pickup();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();

        if (vinchester.GetComponent<Rigidbody>().isKinematic == true)
        {
           
            vinchester.GetComponent<Outline>().enabled = false;
            Stick.GetComponent<Shooting>().enabled = false;
            Sword.GetComponent<Shooting>().enabled = false;

       
        }
        else if (Stick.GetComponent<Rigidbody>().isKinematic == true)
        {
            Stick.GetComponent<Outline>().enabled = false;
            Sword.GetComponent<Shooting>().enabled = false;
            vinchester.GetComponent<ShootingVin>().enabled = false;

           
        }
        else if (Sword.GetComponent<Rigidbody>().isKinematic == true)
        {
            Sword.GetComponent<Outline>().enabled = false;
            Stick.GetComponent<Shooting>().enabled = false;
            vinchester.GetComponent<ShootingVin>().enabled = false;
        }
    }
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
                currenWeapon.GetComponent<Collider>().isTrigger = true;
                currenWeapon.transform.parent = transform;
                currenWeapon.transform.localPosition = Vector3.zero;
                currenWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                canPickUp = true;
                hand.SetActive(true);
                aim.SetActive(true);


            }
        }

    }
    void Drop()
    {
        currenWeapon.transform.parent = null;
        currenWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currenWeapon.GetComponent<Collider>().isTrigger = false;
        currenWeapon.GetComponent<Outline>().enabled = true;
        canPickUp = false;
        currenWeapon = null;
        hand.SetActive(false);
        aim.SetActive(false);

        

        vinchester.GetComponent<ShootingVin>().enabled = true;
        Stick.GetComponent<Shooting>().enabled = true;
        Sword.GetComponent<Shooting>().enabled = true;
    }
}

