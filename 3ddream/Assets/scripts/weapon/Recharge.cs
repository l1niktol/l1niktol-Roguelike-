using UnityEngine;
using UnityEngine.UI;

public class Recharge : MonoBehaviour
{
    public int maxAmmo = 6; // максимальное количество патронов в магазине
    public int totalAmmo = 50; // общее количество патронов у игрока
    public int currentAmmo; // текущее количество патронов в магазине
    public float reloadTime = 2f; // время перезарядки в секундах
    public bool isReloading = false; // флаг, показывающий, идет ли перезарядка
    //public Animator animator;
    //public AudioSource audioSource; // компонент аудиоисточника
    //public AudioClip reloadSound; // звук перезарядки
    //public Text currentAmmoText; // текстовый элемент для отображения патронов в магазине
    //public Text totalAmmoText; // текстовый элемент для отображения общего количества патронов


    public Image[] bullets;

    public Sprite fullBullet;
    public Sprite EmptyBullet;//пока нормально не реализовал


    void Start()
    {
        currentAmmo = maxAmmo; // при старте заполняем магазин полностью
        UpdateAmmoUI(); // обновляем текстовые элементы

    }

    void Update()
    {


        if (isReloading) // если идет перезарядка, то ничего не делаем
            return;

        if (Input.GetKeyDown(KeyCode.R)) // если нажата клавиша R, то начинаем перезарядку
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
        if (totalAmmo == 0) // если у игрока нет патронов, то ничего не делаем
            return;

        isReloading = true; // устанавливаем флаг перезарядки
                            //  animator.SetBool("Reloading", true); // запускаем анимацию перезарядки
                            //   audioSource.PlayOneShot(reloadSound); // проигрываем звук перезарядки

        // вызываем метод FinishReload через reloadTime секунд
        Invoke("FinishReload", reloadTime);
    }

    void FinishReload()
    {
        isReloading = false; // сбрасываем флаг перезарядки
                             //   animator.SetBool("Reloading", false); // останавливаем анимацию перезарядки

        // вычисляем, сколько патронов нужно добавить в магазин
        int ammoToReload = Mathf.Min(maxAmmo - currentAmmo, totalAmmo);

        // уменьшаем общее количество патронов у игрока на это число
        totalAmmo -= ammoToReload;

        // увеличиваем текущее количество патронов в магазине на это число
        currentAmmo += ammoToReload;

           UpdateAmmoUI(); // обновляем текстовые элементы
    }

    void UpdateAmmoUI()
    {
        //    // устанавливаем текстовым элементам значения currentAmmo и totalAmmo
        //    currentAmmoText.text = currentAmmo.ToString();
        //    totalAmmoText.text = totalAmmo.ToString();
        for (int i = 0; i < bullets.Length; i++)
        { 
            bullets[i].sprite = fullBullet;
        }
    }
}
