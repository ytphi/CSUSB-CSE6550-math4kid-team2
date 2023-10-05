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
    //public Text Question;
    public TextMeshProUGUI Question,Answer1,Answer2,Answer3;

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
        QuestionGenerate();
    }
    public void QuestionGenerate()
    {
        int value1 = Random.Range(1, 10);
        int value2 = Random.Range(1, 10);
        int answer;
        if (value1 > value2)
        {
            Question.text = " " + value1 + " - " + value2 + " = ?";
            answer = value1-value2;
        }
        else {
            Question.text = " " + value2 + " - " + value1 + " = ?";
            answer = value2-value1;
        }
        int i= Random.Range(1, 3);
        if (i == 1)
        {
            Answer1.text = answer + "";
            Answer2.text = Random.Range(1, 10)+"";
            Answer3.text = Random.Range(1, 10)+"";
        }
        else if(i == 2)
        {
            Answer2.text = answer + "";
            Answer1.text = Random.Range(1, 10)+"";
            Answer3.text = Random.Range(1, 10)+"";
        }
        else
        {
            Answer3.text = answer + "";
            Answer2.text = Random.Range(1, 10)+"";
            Answer1.text = Random.Range(1, 10)+"";
        }
       
        
        
        Debug.Log(Question.text);
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
