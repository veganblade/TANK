using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveTank : MonoBehaviour
{
    public float speed = 10;         //скорость танка
    public float turnspeed = 25;     //скорость поворота танка
    public GameObject bullet;        //объект пули
    public GameObject muzzel;        //объект снаряда
    private Vector3 SpawnPoint;      //точка появления пули
    public GameObject Shell;         //объект пули


 

    void Start()
    {
        
    }


    void Update()
    {
        Fire();
        float horizontalinput = Input.GetAxis("Horizontal");        //кнопки ввода горизонтали
        float verticalinput = Input.GetAxis("Vertical");            //кнопки ввода вертикали
        transform.Translate(speed * Time.deltaTime * Vector3.forward * verticalinput);      //движение танка вперед-назад
        transform.Rotate(Vector3.up, turnspeed * Time.deltaTime * horizontalinput);     //движение танка влево-вправо

        
    }
    void Fire()
    {
        if(Input.GetButtonUp("Fire"))           //условие выстрела
        {
            SpawnPoint = muzzel.transform.position;
            Quaternion SpawnRoot = muzzel .transform.rotation;
            Shell = Instantiate(bullet, SpawnPoint, SpawnRoot);

            Rigidbody ShellMove = Shell.GetComponent<Rigidbody>();
            ShellMove.AddForce(Shell.transform.forward * 45, ForceMode.Impulse);
            Destroy(Shell, 5);
        }
    }
}
