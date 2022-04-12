using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                //библиотека UI элементов для индикатора жизни

public class hp : MonoBehaviour
{
    public float damage = 10;        //урок от пули
                                     
    public float maxhp = 100;       //создание жизни
    public float hpNow = 100;

    public Canvas hpUI;              //холст
    public Slider SliderHpNow;       //индикатор жизни на данный момент

    public Transform metka;          //точка рассположения для индикатора жизни
    public Camera MyCamera;
    Slider myShowHP;

    public GameObject TankOrig;
    public GameObject TankDead;

    void Start()
    {
        myShowHP = (Slider)Instantiate(SliderHpNow);                //создаем слайдер на основе эталона
        myShowHP.transform.SetParent(hpUI.transform, true);      //объявляем что он будет расположен на холсте
    }


    void Update()
    {
        if (myShowHP != null && hpNow <= 100)
        {
            //получаем экранные координатырасположения танка
            Vector3 screenPos = MyCamera.WorldToScreenPoint(metka.position);
            //задаем координаты расположения ХП
            myShowHP.transform.position = screenPos;
            myShowHP.value = hpNow;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
            hpNow -= damage;
        if (hpNow < 1)
        {
            Destroy(this.gameObject);
            Replace(TankOrig, TankDead);
        }
        else if (hpNow < 0)
        {

            Destroy(hpUI.gameObject);
            Destroy(SliderHpNow);
            Destroy(myShowHP);

        }
    }
    void Replace(GameObject obj1, GameObject obj2)
    {
        Instantiate(obj2, obj1.transform.position, Quaternion.identity);
        Destroy(obj1);
    }
}
