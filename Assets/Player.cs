using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.Globalization;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class Player : MonoBehaviour
{
    float horizontal;
    bool hitGhost;
    Light l;
    GameObject ghost;

    float time;
    bool time_set;


    SerialPort stream = new SerialPort("COM5", 9600);


    float AccX;

    float previous_AccY;
    float AccY;
    int AccZ;


    float middlePoint;
    float rightmostPoint;
    float leftmostPoint;


    int x;

    public int score;

    [SerializeField] GameManager g ;

    


    [SerializeField] GameObject cursor;


    [SerializeField] Button button0;
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;

    float multiplier;

    [SerializeField] GameObject endScreen;



    [SerializeField] TMP_Text text;


    float debounceTime;
    float debounceTime2;

    public void setMiddle()
    {
        
        middlePoint = AccY;

    }
    public void setLeft()
    {
        rightmostPoint = AccY;
    }
    public void setRight()
    {
        leftmostPoint = AccY;
    }




    public void mapping()
    {/*
        float h =leftmostPoint - rightmostPoint;
        print(leftmostPoint);
        print(rightmostPoint);
        
       
        multiplier = Screen.currentResolution.width / h;

        */
    }









    private void Start()
    {
        score = 0;
        stream.Open();
        l = transform.GetChild(0).GetChild(0).GetComponent<Light>();
        x = 0;
        multiplier = 1;
        cursor.SetActive(false);
    
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }



        string UnSplitData = stream.ReadLine();
        
        if (x < 100)
        {
            x++;
        }
        else
        {

            string[] SplitData = UnSplitData.Split('/');

            AccX = float.Parse(SplitData[0], CultureInfo.InvariantCulture.NumberFormat);
            AccY = -float.Parse(SplitData[1], CultureInfo.InvariantCulture.NumberFormat);
            AccZ = int.Parse(SplitData[2]);
           
            //print(UnSplitData);

            if(g.state>3)
            cursor.GetComponent<RectTransform>().localPosition = new Vector3(AccY, AccX, 0) * 25 ;
            




        }


        if (AccZ == 1 && Time.time - debounceTime>3)
        {
            debounceTime = Time.time;
            switch (g.state)
            {
                case 0:
                    button0.onClick.Invoke();
                    
                    
                    break;
                case 1:
                    button1.onClick.Invoke();
                    
                   
                    break;
                case 2:
                    button2.onClick.Invoke();
                    
                    
                    break;
                case 3:
                    button3.onClick.Invoke();
                    mapping();

                    
                    
                    
                    break;

                //-17, -8, 0, 9, 17.5
                case 5:
                    
                    
                    if (!time_set)
                    {
                       
                        time_set = true;
                        time = Time.time;
                    }
                    if (cursor.GetComponent<RectTransform>().localPosition.y < 80 && cursor.GetComponent<RectTransform>().localPosition.y > -140 && cursor.GetComponent<RectTransform>().localPosition.x < -456 && cursor.GetComponent<RectTransform>().localPosition.x > -580)
                    {
                        if (g.selected == 0)
                        {
                            g.current.transform.GetChild(0).gameObject.SetActive(true);
                            score += 10;
                            print("+10 p");
                        }
                        else
                        {
                            print("0 p");
                        }

                        transform.position = new Vector3(-17, 0, 19.96f);

                        l.enabled = true;
                        g.state++;
                        print("Door 0 is clicked");
                    }
                    else if (cursor.GetComponent<RectTransform>().localPosition.y < 80 && cursor.GetComponent<RectTransform>().localPosition.y > -158 && cursor.GetComponent<RectTransform>().localPosition.x < -185 && cursor.GetComponent<RectTransform>().localPosition.x > -381)
                    {
                        if (g.selected == 1)
                        {
                            g.current.transform.GetChild(0).gameObject.SetActive(true);
                            score += 10;
                            print("+10 p");
                        }
                        else
                        {
                            print("0 p");
                        }
                        transform.position = new Vector3(-8, 0, 19.96f);

                        l.enabled = true;
                        g.state++;
                        print("Door 1 is clicked");
                    }
                    else if (cursor.GetComponent<RectTransform>().localPosition.y < 80 && cursor.GetComponent<RectTransform>().localPosition.y > -160 && cursor.GetComponent<RectTransform>().localPosition.x < 70 && cursor.GetComponent<RectTransform>().localPosition.x > -37)
                    {
                        if (g.selected == 2)
                        {
                            g.current.transform.GetChild(0).gameObject.SetActive(true);
                            score += 10;
                            print("+10 p");
                        }
                        else
                        {
                            print("0 p");
                        }
                        transform.position = new Vector3(0, 0, 19.96f);

                        l.enabled = true;
                        g.state++;
                        print("Door 2 is clicked");
                    }
                    else if (cursor.GetComponent<RectTransform>().localPosition.y < 90 && cursor.GetComponent<RectTransform>().localPosition.y > -160 && cursor.GetComponent<RectTransform>().localPosition.x < 332 && cursor.GetComponent<RectTransform>().localPosition.x > 211)
                    {
                        if (g.selected == 3)
                        {
                            g.current.transform.GetChild(0).gameObject.SetActive(true);
                            score += 10;
                            print("+10 p");
                        }
                        else
                        {
                            print("0 p");
                        }
                        transform.position = new Vector3(9, 0, 19.96f);

                        l.enabled = true;
                        g.state++;
                        print("Door 3 is clicked");
                    }
                    else if (cursor.GetComponent<RectTransform>().localPosition.y < 85 && cursor.GetComponent<RectTransform>().localPosition.y > -160 && cursor.GetComponent<RectTransform>().localPosition.x < 596 && cursor.GetComponent<RectTransform>().localPosition.x > 450)
                    {
                        if (g.selected == 4)
                        {
                            g.current.transform.GetChild(0).gameObject.SetActive(true);
                            score += 10;
                            print("+10 p");
                        }
                        else
                        {
                            print("0 p");
                        }
                        transform.position = new Vector3(17.5f, 0, 19.96f);

                        l.enabled = true;
                        g.state++;
                        print("Door 4 is clicked");
                    }
                    
                    
                    break;

                    
                case 6:
                    
                    if(Time.time-time<75)
                    {





                        l.enabled = false;
                        g.state = 4;
                    }
                    else
                    {
                        time_set = false;
                        g.state++;
                        debounceTime2 = Time.time;

                    }
                    break;

                case 7:

                    
                    endScreen.SetActive(true);
                    text.SetText("Skor: "+ score.ToString()) ;
                    
                    
                    break;
                    
            }
        }

        
        //horizontal = Input.GetAxis("Mouse X") * 90 * Time.deltaTime;
        
        //transform.Rotate(0, horizontal, 0);

        //hitGhost = false;
        /*
        for(int i=0; i<11;i++)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.2588f + i * 0.05176f, 0, 0.9659f)), Color.green);
        }*/
        


        


    }
}
