using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveTank : MonoBehaviour
{
    public float speed = 10;         //�������� �����
    public float turnspeed = 25;     //�������� �������� �����
    public GameObject bullet;        //������ ����
    public GameObject muzzel;        //������ �������
    private Vector3 SpawnPoint;      //����� ��������� ����
    public GameObject Shell;         //������ ����


 

    void Start()
    {
        
    }


    void Update()
    {
        Fire();
        float horizontalinput = Input.GetAxis("Horizontal");        //������ ����� �����������
        float verticalinput = Input.GetAxis("Vertical");            //������ ����� ���������
        transform.Translate(speed * Time.deltaTime * Vector3.forward * verticalinput);      //�������� ����� ������-�����
        transform.Rotate(Vector3.up, turnspeed * Time.deltaTime * horizontalinput);     //�������� ����� �����-������

        
    }
    void Fire()
    {
        if(Input.GetButtonUp("Fire"))           //������� ��������
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
