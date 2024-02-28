using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingVin : MonoBehaviour
{
    public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;

    public float shootForce;
    public float spread;

    public GameObject hand;
    public bool canShoot = true;



    public int maxAmmo = 6; // ������������ ���������� �������� � ��������
    public int totalAmmo = 50; // ����� ���������� �������� � ������
    public int currentAmmo; // ������� ���������� �������� � ��������
    public float reloadTime = 2f; // ����� ����������� � ��������
    public bool isReloading = false; // ����, ������������, ���� �� �����������
    // public Animator animator; 
    //  public AudioSource audioSource; // ��������� ��������������
    //  public AudioClip reloadSound; // ���� �����������
    //  public Text currentAmmoText; // ��������� ������� ��� ����������� �������� � ��������
    //  public Text totalAmmoText; // ��������� ������� ��� ����������� ������ ���������� ��������


    public Image[] bullets;

    public Sprite fullBullet;
    public Sprite EmptyBullet;

    public void Start()
    {
        currentAmmo = maxAmmo; // ��� ������ ��������� ������� ���������
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hand.activeSelf)
        {
            Shoot();
            currentAmmo -= 1;
        }




        if (isReloading) // ���� ���� �����������, �� ������ �� ������
            return;

        if (Input.GetKeyDown(KeyCode.R)) // ���� ������ ������� R, �� �������� �����������
        {
            Reload();

        }

        if (maxAmmo > currentAmmo)
        {
            maxAmmo = currentAmmo;
        }
        for (int i = 0; i < bullets.Length; i++)
        {
            if (i < maxAmmo)
            {
                bullets[i].sprite = fullBullet;
            }
            else
            {
                bullets[i].sprite = EmptyBullet;
            }
        }

        if (Input.GetMouseButtonDown(0) && GetComponent<Rigidbody>().isKinematic == true)
        {
            maxAmmo -= 1;
        }
    }


    private void Shoot()
    {
        if (!canShoot) //���� �������� ���������, �� ������� �� ������
            return;


        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
        //if (character.isDead || ammo == 0 || Time.time < nextShootTime)
        //{
        //    canShoot = false;
        //}
        //else
        //{
        //    canShoot = true;
        //}

    }


void Reload()
{
    if (totalAmmo == 0) // ���� � ������ ��� ��������, �� ������ �� ������
        return;

    isReloading = true; // ������������� ���� �����������
                        //  animator.SetBool("Reloading", true); // ��������� �������� �����������
                        //   audioSource.PlayOneShot(reloadSound); // ����������� ���� �����������
        canShoot = false;
        // �������� ����� FinishReload ����� reloadTime ������
        Invoke("FinishReload", reloadTime);
}

void FinishReload()
{
    isReloading = false; // ���������� ���� �����������
                         //   animator.SetBool("Reloading", false); // ������������� �������� �����������
        canShoot = true;
        // ���������, ������� �������� ����� �������� � �������
        int ammoToReload = Mathf.Min(maxAmmo - currentAmmo, totalAmmo);

    // ��������� ����� ���������� �������� � ������ �� ��� �����
    totalAmmo -= ammoToReload;

    // ����������� ������� ���������� �������� � �������� �� ��� �����
    currentAmmo += ammoToReload;

    //   UpdateAmmoUI(); // ��������� ��������� ��������
}

    //void UpdateAmmoUI()
    //{
    //    // ������������� ��������� ��������� �������� currentAmmo � totalAmmo
    //    currentAmmoText.text = currentAmmo.ToString();
    //    totalAmmoText.text = totalAmmo.ToString();
    //}
}

