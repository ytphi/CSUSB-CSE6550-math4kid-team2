using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using Microsoft.AppCenter.Unity.Analytics;



public class PlayWithKids : MonoBehaviour
{
    
    public Transform Dog,Monster, parentCanvas, Fruitposition;
    public float speed;
    public GameObject Fruit, monster_obj;
    public Vector3 startPosition;
    public static int consequtive_ques_no = 5, score_value = 0;
    public int value1, value2, answer, progress = 0;
    public TextMeshProUGUI Question, Answer1, Answer2, Answer3, Answer4;
    public Slider slider_value;
    public List<Sprite> imageOptions = new List<Sprite>();
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("fruite: " + Fruitposition.position);
        startPosition = new Vector3(Monster.position.x, Monster.position.y, Monster.position.z);
        Debug.Log("monster: " + startPosition);
        QuestionGenerate();
    }
    public void QuestionGenerate()
    {
        if(consequtive_ques_no == 0)
        {
            if (score_value == 5)
            {

                consequtive_ques_no = 5;
                score_value = 0;
                scoreManager = new ScoreManager();
                Debug.Log("Increase score");
                scoreManager.IncreaseScore();
                SceneManager.LoadScene("scene3_congratulation");
            }
            else
            {
                consequtive_ques_no = 5;
                score_value = 0;
                SceneManager.LoadScene("scene4_tryagain_update");
            }

        }
        else
        {
            GenerateQuestion();
        }
         
        
        
    }
    private void GenerateQuestion()
    {
        value1 = Random.Range(1, 10);
        value2 = Random.Range(1, 10);

        string question;
        if (value1 > value2)
        {
            question = $"  {value1} - {value2}  = ?";
        }
        else
        {
            question = $"  {value2} - {value1}  = ?";
        }

        Debug.Log(question);
        StartCoroutine(DisplayTextPanel(question));

        answer = (value1 > value2) ? value1 - value2 : value2 - value1;

        DisplayAnswers();
    }
    private void DisplayAnswers()
    {
        int correctAnswerIndex = Random.Range(1, 5);
        List<int> usedAnswers = new List<int> { answer };

        for (int i = 1; i <= 4; i++)
        {
            if (i == correctAnswerIndex)
            {
                SetAnswerText(i, answer.ToString());
            }
            else
            {
                int randomAnswer = GetUniqueRandomAnswer(usedAnswers);
                SetAnswerText(i, randomAnswer.ToString());
                usedAnswers.Add(randomAnswer);
            }
        }
    }

    private int GetUniqueRandomAnswer(List<int> usedAnswers)
    {
        int randomAnswer = Random.Range(1, 10);
        while (usedAnswers.Contains(randomAnswer))
        {
            randomAnswer = Random.Range(1, 10);
        }
        return randomAnswer;
    }

    private void SetAnswerText(int index, string text)
    {
        switch (index)
        {
            case 1:
                Answer1.text = text;
                break;
            case 2:
                Answer2.text = text;
                break;
            case 3:
                Answer3.text = text;
                break;
            case 4:
                Answer4.text = text;
                break;
            default:
                break;
        }
    }

    public void FixedUpdate()
    {
        Monster.position = Vector3.MoveTowards(Monster.position, Dog.position, speed);
       
        float distance = Vector3.Distance(Monster.position, Dog.position);
        
    }

    // Update is called once per frame
    public IEnumerator DisplayTextPanel(string text)
    {
        Question.text = "";
        foreach (char item in text.ToCharArray())
        {
            Question.text += item;
            yield return new WaitForSeconds(0.04f);
        }
    }
    public void CheckAnswer(Button button_colour)
    {
        TextMeshProUGUI button_answer = button_colour.GetComponentInChildren<TextMeshProUGUI>();
        Image image = button_colour.GetComponent<Image>();
        if (button_answer.text == answer.ToString())
        {
            StartCoroutine(ChangeColorCoroutine(button_colour, Color.green));
            ThrowObject();
            consequtive_ques_no--;
            score_value++;

                // Debug.Log("start wait");
            StartCoroutine(ResetThrowCooldownStart());
                // Debug.Log("end wait");

            


        }
        else
        {


            
                consequtive_ques_no--;
                StartCoroutine(ChangeColorCoroutine(button_colour, Color.red));
                string answerwithquestion = Question.text;
                char[] charArray = answerwithquestion.ToCharArray();
                charArray[answerwithquestion.Length - 1] = answer.ToString()[0];

                string v = new string(charArray);
                Debug.Log("answer" + v);
                StartCoroutine(DisplayTextPanel(v));
                StartCoroutine(WaitTime());

            

        }
        progress++;
        slider_value.value = progress;


    }
    IEnumerator ResetThrowCooldownStart()
    {

        //Debug.Log(Time.time);
        yield return new WaitForSeconds(2.0f);


        //Monster.position = startPosition;
        Monster.position = startPosition;

        monster_obj.SetActive(true);
        int randomIndex = Random.Range(0, imageOptions.Count);
        SpriteRenderer spriteRenderer = monster_obj.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = imageOptions[randomIndex];
        }
        else
        {
            Debug.LogError("SpriteRenderer component not found on the imageComponent GameObject.");
        }
       // startPosition = new Vector3(Monster.position.x, Monster.position.y, Monster.position.z);
        QuestionGenerate();

        //yield return new WaitForSeconds(1.0f);
        // Debug.Log(Time.time);



    }
    public IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2.0f);
        QuestionGenerate();
    }
    private IEnumerator ChangeColorCoroutine(Button button_image, Color c)
    {
        Image image = button_image.GetComponent<Image>();
        Color original = image.color;
        if (image != null)
        {
            image.color = c;

            yield return new WaitForSeconds(1.0f);

            image.color = original;
        }
    }
    public void ThrowObject()
    {
        // Create a new instance of the object to throw
        GameObject fruitClone = Instantiate(Fruit, Fruitposition.position, Quaternion.identity);

        // Set the parent of the cloned object to the main camera
         fruitClone.transform.SetParent(parentCanvas, false);
        //fruitClone.transform.position = Vector3.MoveTowards(fruitClone.transform.position, Monster.position, speed * Time.deltaTime);

        // Calculate the direction from the monster to the target
        Vector3 direction = (Monster.position - Dog.position).normalized;

        Rigidbody2D rb = fruitClone.GetComponent<Rigidbody2D>();

        // Apply force to the fruit in the up direction and towards the monster
        
        Vector2 throwingVelocity = (Vector3.up * 3.0f)+(Fruitposition.right * 15.0f) ;
        rb.velocity = throwingVelocity;
        // Debug information
        Debug.Log(fruitClone.name);
        Debug.Log("Clone position: " + fruitClone.transform.position);
        Debug.Log("Direction: " + direction);
    }

}
