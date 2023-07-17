using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera cam0;
    [SerializeField] Camera cam1;

    [SerializeField] GameObject location0;
    [SerializeField] GameObject location1;
    [SerializeField] GameObject location2;
    [SerializeField] GameObject location3;
    [SerializeField] GameObject location4;

    [SerializeField] GameObject ghost;
    public GameObject current;

    [SerializeField] GameObject player;



    [SerializeField] GameObject cursor;

    public int state;
    public int selected;



    // Start is called before the first frame update
    void Start()
    {

        selected = -1;
        state = 0;
        
    }


    



    public void changeState()
    {
        state++;
    }



    private void Update()
    {
        
        switch (state)
        {
            case 4:
                DestroyImmediate(current,true);


                
                float rand = Random.Range(0f, 1f)*Time.time % 1;
                player.transform.position = new Vector3(0, 0, 19.96f);
                if(rand<0.2f)
                {
                    current = Instantiate(ghost, location0.transform);
                    location0.GetComponent<AudioSource>().Play();
                    selected = 2;
                    
                }
                else if(rand < 0.4f)
                {
                    current = Instantiate(ghost, location1.transform);
                    location1.GetComponent<AudioSource>().Play();
                    selected = 3;
                }
                else if(rand < 0.6f)
                {
                    current = Instantiate(ghost, location2.transform);
                    location2.GetComponent<AudioSource>().Play();
                    selected = 1;
                }
                else if(rand < 0.8f)
                {
                    current = Instantiate(ghost, location3.transform);
                    location3.GetComponent<AudioSource>().Play();
                    selected = 4;
                }
                else
                {
                    current = Instantiate(ghost, location4.transform);
                    location4.GetComponent<AudioSource>().Play();
                    selected = 0;
                }


                Thread.Sleep(5000);
                cursor.SetActive(true);
                state++;
                break;


        }
         
        
    }


}
