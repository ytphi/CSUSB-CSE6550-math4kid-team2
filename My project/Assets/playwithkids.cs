using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playwithkids : MonoBehaviour
{
   
    public Image QuestionPanel;
    public Transform dog,monster;
    public float speed;
    void Start()
    {

    }
    void FixedUpdate()
    {   
        monster.position=Vector3.MoveTowards(monster.position,dog.position,speed);
    }
    // Update is called once per frame
    void Update()
    {
        //QuestionPanel.GetComponent<Text>().text = "hello world";
            //"  " + Random.Range(1, 10) + "  -  " + Random.Range(1, 10);
    }
}
