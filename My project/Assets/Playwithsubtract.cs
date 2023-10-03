using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Playwithsubtract : MonoBehaviour
{
    public Transform Dog;
    public Transform Monster;
    public float speed;
    //public TextMeshPro Question;

    // Start is called before the first frame update
    void Start()
    {

        //Question= GameObject.Find("Question_panel/Question_text").GetComponent<Text>();
        /*if(Question != null)
        {
            Question.text = Random.Range(1, 10)+"";
        }
        else
        {
            Debug.Log("No object");
        }*/
    }
    public void FixedUpdate()
    {
        Monster.position = Vector3.MoveTowards(Monster.position, Dog.position, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
