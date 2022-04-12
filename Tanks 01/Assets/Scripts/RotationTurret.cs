using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTurret : MonoBehaviour
{
    public float rotationSpeed = 35;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     float VerticalInput = Input.GetAxis("MoveTurret");
     transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * VerticalInput);
    }
   
}
