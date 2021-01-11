using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class computer_1 : MonoBehaviour
{

    public bool using_computers = false;
    GameObject the_computer;

    float startTime = 0f;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (using_computers)
        {
            string computer_text = the_computer.GetComponentInChildren<Text>().text;
            if (Input.anyKeyDown == true && Input.GetKeyDown(KeyCode.Backspace) != true)
            {
                the_computer.GetComponentInChildren<Text>().text = computer_text + Input.inputString;
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                del_last_letter();
                StartCoroutine(backspace_hold());
            }
           
        }

        if (the_computer != null)
        {
            
            if (Input.GetButtonDown("Interact"))
            {
               

                if (using_computers == false)
                {
                    using_computers = true;
                }

            }
        }

        if (Input.GetButtonDown("Exit"))
        {
            using_computers = false;
        }



    }

    IEnumerator backspace_hold()
    {

     
       
       startTime = Time.time;
        while (Input.GetKey(KeyCode.Backspace))
            { 
        float timepass = Time.time - startTime;
        Debug.Log(timepass);
            if (timepass > 1f)
            {
                del_last_letter();
               
            }
            yield return new WaitForSeconds(0.03f);
        }


    }

    void del_last_letter()
    {
        string computer_text = the_computer.GetComponentInChildren<Text>().text;
        if (computer_text != "")
        {

            the_computer.GetComponentInChildren<Text>().text = computer_text.Remove(computer_text.Length - 1);
        }
    }


    private void OnTriggerEnter(Collider computer)
    {
 
        the_computer = computer.gameObject;


    }

    private void OnTriggerExit(Collider other)
    {
        the_computer = null;
        using_computers = false;
    }
}
