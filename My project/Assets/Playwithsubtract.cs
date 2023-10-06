using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class Playwithsubtract : MonoBehaviour
{
    public Transform Dog;
    public Transform Monster;
    public float speed;
    //public Text Question;
    public TextMeshProUGUI Question, Answer1, Answer2, Answer3;
    public int value1, value2, answer;
    public static int consequtive_ques_no = 5;

    // Start is called before the first frame update
    void Start()
    {


        QuestionGenerate();
        //CheckAnswer(button_answer,sceneName1,sceneName2);
    }
    public void QuestionGenerate()
    {
        value1 = Random.Range(1, 10);
        value2 = Random.Range(1, 10);

        if (value1 > value2)
        {
            Question.text = " " + value1 + " - " + value2 + " = ?";
            answer = value1 - value2;
        }
        else {
            Question.text = " " + value2 + " - " + value1 + " = ?";
            answer = value2 - value1;
        }
        int i = Random.Range(1, 3);
        if (i == 1)
        {
            Answer1.text = answer + "";
            Answer2.text = Random.Range(1, 10) + "";
            Answer3.text = Random.Range(1, 10) + "";
        }
        else if (i == 2)
        {
            Answer2.text = answer + "";
            Answer1.text = Random.Range(1, 10) + "";
            Answer3.text = Random.Range(1, 10) + "";
        }
        else
        {
            Answer3.text = answer + "";
            Answer2.text = Random.Range(1, 10) + "";
            Answer1.text = Random.Range(1, 10) + "";
        }
        


       
    }
    public void FixedUpdate()
    {
        Monster.position = Vector3.MoveTowards(Monster.position, Dog.position, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckAnswer(TextMeshProUGUI button_answer)//, string sceneName1, string sceneName2)
    {
        if (button_answer.text == answer.ToString())
        {
            if(consequtive_ques_no!=0)
            {
                consequtive_ques_no--;
                QuestionGenerate();
            }
            //SceneManager.LoadScene("mainmenuscene");
            Debug.Log("correct");
        }
        else
        {
            if (consequtive_ques_no != 0)
            {
                consequtive_ques_no--;
                QuestionGenerate();
            }
            //SceneManager.LoadScene("scene4_tryagain");
            Debug.Log("wrong");
        }
        
    }
}
