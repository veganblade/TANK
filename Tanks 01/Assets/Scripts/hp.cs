using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                //���������� UI ��������� ��� ���������� �����

public class hp : MonoBehaviour
{
    public float damage = 10;        //���� �� ����
                                     
    public float maxhp = 100;       //�������� �����
    public float hpNow = 100;

    public Canvas hpUI;              //�����
    public Slider SliderHpNow;       //��������� ����� �� ������ ������

    public Transform metka;          //����� ������������� ��� ���������� �����
    public Camera MyCamera;
    Slider myShowHP;

    public GameObject TankOrig;
    public GameObject TankDead;

    void Start()
    {
        myShowHP = (Slider)Instantiate(SliderHpNow);                //������� ������� �� ������ �������
        myShowHP.transform.SetParent(hpUI.transform, true);      //��������� ��� �� ����� ���������� �� ������
    }


    void Update()
    {
        if (myShowHP != null && hpNow <= 100)
        {
            //�������� �������� ���������������������� �����
            Vector3 screenPos = MyCamera.WorldToScreenPoint(metka.position);
            //������ ���������� ������������ ��
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
