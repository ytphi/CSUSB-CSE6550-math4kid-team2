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
    public TextMeshProUGUI Question, Answer1, Answer2, Answer3,Score_text;
    public int value1, value2, answer;
    public static int consequtive_ques_no = 5,score_value;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Monster.position);
        startPosition = new Vector3 (Monster.position.x, Monster.position.y, Monster.position.z);
        QuestionGenerate();
        
    }
    public void QuestionGenerate()
    {
        if(score_value==5 & consequtive_ques_no ==0)
        {
            consequtive_ques_no = 5; score_value=0;
            LoadScene("scene3_congratulation");
        }
        else if(score_value < 5 & consequtive_ques_no == 0)
        {
            consequtive_ques_no = 5; score_value = 0;
            LoadScene("scene4_tryagain");
        }
        else
        {
            value1 = Random.Range(1, 10);
            value2 = Random.Range(1, 10);

            if (value1 > value2)
            {
                Question.text = " " + value1 + " - " + value2 + " = ?";
                answer = value1 - value2;
            }
            else
            {
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
        
        


       
    }
    public void FixedUpdate()
    {
        Monster.position = Vector3.MoveTowards(Monster.position, Dog.position, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckAnswer(TextMeshProUGUI button_answer)
    {
        if (button_answer.text == answer.ToString())
        {

            //Monster.SetPositionAndRotation(new Vector3(682.00f, 110.45f, 0.00f), Quaternion.identity);
            Monster.position = startPosition;
            if (consequtive_ques_no!=0)
            {
                consequtive_ques_no--;
                score_value++;
                Score_text .text= score_value + "";
                QuestionGenerate();
            }
            
            //SceneManager.LoadScene("mainmenuscene");
           // Debug.Log("correct");
        }
        else
        {
            if (consequtive_ques_no != 0)
            {
                consequtive_ques_no--;
                QuestionGenerate();
            }
            //SceneManager.LoadScene("scene4_tryagain");
            //Debug.Log("wrong");
        }
        
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
}
