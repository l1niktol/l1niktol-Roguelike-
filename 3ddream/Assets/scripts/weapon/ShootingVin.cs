using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingVin : MonoBehaviour
{
    public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;

    public float shootForce;//сила выстрела
    public float spread; // разброс

    public GameObject hand;
    public bool canShoot = true;



    public int maxAmmo = 6; // максимальное количество патронов в магазине
    public int totalAmmo = 20; // общее количество патронов
    public int currentAmmo; // текущее количество патронов 
    public float reloadTime = 2f; // время перезарядки
    public bool isReloading = false;
    //  public AudioSource audioSource; // компонент аудиоисточника
    //  public AudioClip reloadSound; // звук перезарядки
    //  public Text currentAmmoText; // текстовый элемент для отображения патронов в магазине
    //  public Text totalAmmoText; // текстовый элемент для отображения общего количества патронов
    public Animator vinchesterkAnimation;

    public Image[] bullets; //массив аикч

    public Sprite fullBullet; //пикчи фулл
    public Sprite EmptyBullet; //пикчи пустых

    public GameObject expPrefab; //префаб дыма
    public GameObject SpawnSmoke; //спавн



    public float fireRate = 0.5f; // задержка в секундах между выстрелами
    private float lastFireTime; // время последнего выстрела

    public void Start()
    {
        currentAmmo = maxAmmo; // при старте заполняем магазин полностью
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hand.activeSelf)
        {
            if (Input.GetMouseButton(0))
            {
                // если прошло достаточно времени с последнего выстрела
                if (Time.time - lastFireTime >= fireRate)
                {
                    // производим выстрел
                    Shoot();
                    // обновляем время последнего выстрела
                    lastFireTime = Time.time;
                }
            }
            
            
        }
        if (isReloading) // если идет перезарядка, то ничего не делаем
            return;

        if (Input.GetKeyDown(KeyCode.R)) // если нажата клавиша R, то начинаем перезарядку
        {
            Reload();

        }

        //if (maxAmmo > currentAmmo)
        //{
        //    maxAmmo = currentAmmo;
        //}
        if(currentAmmo == 0)
        {
            Reload();
        }
        if(totalAmmo == 0 && currentAmmo == 0)
        {
            canShoot = false;
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
    }


    private void Shoot()
    {
        if (!canShoot) //Если стрельба запрещена, то выходим из метода
            return;

        currentAmmo -= 1;

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

        vinchesterkAnimation.Play("VinAnim");
        GameObject exp1 = Instantiate(expPrefab) as GameObject;
        exp1.transform.position = SpawnSmoke.transform.position;

    }


void Reload()
{
        if (totalAmmo == 0 ) // если у игрока нет патронов, то ничего не делаем
        return;

        isReloading = true; // устанавливаем флаг перезарядки

        vinchesterkAnimation.SetBool("Reloading", true); // запускаем анимацию перезарядки
        //   audioSource.PlayOneShot(reloadSound); // проигрываем звук перезарядки
        canShoot = false; 
       
        Invoke("FinishReload", reloadTime); // вызываем метод FinishReload через reloadTime секунд
}

void FinishReload()
{
        isReloading = false; // сбрасываем флаг перезарядки
        vinchesterkAnimation.SetBool("Reloading", false); // останавливаем анимацию перезарядки
        canShoot = true;      
        int ammoToReload = Mathf.Min(maxAmmo - currentAmmo, totalAmmo);// вычисляем, сколько патронов нужно добавить в магазин
        totalAmmo -= ammoToReload;// уменьшаем общее количество патронов у игрока на это число
        currentAmmo += ammoToReload;// увеличиваем текущее количество патронов в магазине на это число
        //   UpdateAmmoUI(); // обновляем текстовые элементы
    }

    //void UpdateAmmoUI()
    //{
    //    // устанавливаем текстовым элементам значения currentAmmo и totalAmmo
    //    currentAmmoText.text = currentAmmo.ToString();
    //    totalAmmoText.text = totalAmmo.ToString();
    //}
}

