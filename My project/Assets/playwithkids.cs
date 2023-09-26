using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playwithkids : MonoBehaviour
{
   
    //public GameObject Question_text;
    //public Text button_answer;
    public Transform dog,monster;
    public float speed;
  
    
    
    // Start is called before the first frame update
    void Start()
    {
               // Question_text.GetComponent<Text>().text= "  " + Random.Range(1, 10) + "  -  " + Random.Range(1, 10);
        

    }
    void FixedUpdate()
    {
        //button_answer.text = " " + 5;   
        monster.position=Vector3.MoveTowards(monster.position,dog.position,speed);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
