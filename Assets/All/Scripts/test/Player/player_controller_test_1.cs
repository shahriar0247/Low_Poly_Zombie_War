using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller_test_1 : MonoBehaviour
{
    [Header("Movement")]

    public float speed = 10f;

    private Rigidbody rb;

    computer_1 computer;

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        computer = GetComponent<computer_1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (computer.using_computers == false) { 
        movement();
        }
    }

    void movement()
    {
        // Getting input

        float input_vertical = Input.GetAxis("Vertical");
        float input_horizontal = Input.GetAxis("Horizontal");
        //bool sprint = Input.GetKey("Sprint");
        //Debug.Log(sprint);

        Vector3 direction = new Vector3(input_horizontal * speed, 0, input_vertical * speed);
        rb.velocity = direction;

    }

   
}


