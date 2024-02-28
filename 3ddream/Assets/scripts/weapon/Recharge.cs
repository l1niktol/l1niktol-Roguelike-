using UnityEngine;
using UnityEngine.UI;

public class Recharge : MonoBehaviour
{
    public int maxAmmo = 6; // ������������ ���������� �������� � ��������
    public int totalAmmo = 50; // ����� ���������� �������� � ������
    public int currentAmmo; // ������� ���������� �������� � ��������
    public float reloadTime = 2f; // ����� ����������� � ��������
    public bool isReloading = false; // ����, ������������, ���� �� �����������
    //public Animator animator;
    //public AudioSource audioSource; // ��������� ��������������
    //public AudioClip reloadSound; // ���� �����������
    //public Text currentAmmoText; // ��������� ������� ��� ����������� �������� � ��������
    //public Text totalAmmoText; // ��������� ������� ��� ����������� ������ ���������� ��������


    public Image[] bullets;

    public Sprite fullBullet;
    public Sprite EmptyBullet;//���� ��������� �� ����������


    void Start()
    {
        currentAmmo = maxAmmo; // ��� ������ ��������� ������� ���������
        UpdateAmmoUI(); // ��������� ��������� ��������

    }

    void Update()
    {


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

    void Reload()
    {
        if (totalAmmo == 0) // ���� � ������ ��� ��������, �� ������ �� ������
            return;

        isReloading = true; // ������������� ���� �����������
                            //  animator.SetBool("Reloading", true); // ��������� �������� �����������
                            //   audioSource.PlayOneShot(reloadSound); // ����������� ���� �����������

        // �������� ����� FinishReload ����� reloadTime ������
        Invoke("FinishReload", reloadTime);
    }

    void FinishReload()
    {
        isReloading = false; // ���������� ���� �����������
                             //   animator.SetBool("Reloading", false); // ������������� �������� �����������

        // ���������, ������� �������� ����� �������� � �������
        int ammoToReload = Mathf.Min(maxAmmo - currentAmmo, totalAmmo);

        // ��������� ����� ���������� �������� � ������ �� ��� �����
        totalAmmo -= ammoToReload;

        // ����������� ������� ���������� �������� � �������� �� ��� �����
        currentAmmo += ammoToReload;

           UpdateAmmoUI(); // ��������� ��������� ��������
    }

    void UpdateAmmoUI()
    {
        //    // ������������� ��������� ��������� �������� currentAmmo � totalAmmo
        //    currentAmmoText.text = currentAmmo.ToString();
        //    totalAmmoText.text = totalAmmo.ToString();
        for (int i = 0; i < bullets.Length; i++)
        { 
            bullets[i].sprite = fullBullet;
        }
    }
}
