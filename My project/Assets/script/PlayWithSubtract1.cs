using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using Microsoft.AppCenter.Unity.Analytics;




public class PlayWithSubtract1 : MonoBehaviour
{
    public int frame;
    public Transform Dog;
    public Transform Monster, parentCanvas, Fruitposition;
    public GameObject Fruit, Monster_obj;
    public float speed;
    public TextMeshProUGUI Question, Answer1, Answer2, Answer3,Answer4, Score_text;
    public int value1, value2, answer, progress = 0;
    public static int consequtive_ques_no = 5, score_value, file_score;
    public Vector3 startPosition;
    public Slider slider_value;
    public string File_path, fileContents;
    public Image imageComponent;
    public List<Sprite> imageOptions = new List<Sprite>();




    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        File_path = "Assets/Score_data.txt"; // Update with your file path
        if (File.Exists(File_path))
        {
            fileContents = File.ReadAllText(File_path);
            Debug.Log("File Contents:\n" + fileContents);
        }
        else
        {
            Debug.LogError("File not found at path: " + File_path);
        }
        Score_text.text = " " + fileContents;
        file_score = int.Parse(fileContents);
        Debug.Log(Monster.position);
        startPosition = new Vector3(Monster.position.x, Monster.position.y, Monster.position.z);
        QuestionGenerate();

    }
    public void QuestionGenerate()
    {
        //ScoreData.Scoredata = score_value;
        PlayerPrefs.SetInt("Scoredata", score_value);
        Debug.Log(ScoreData.Scoredata.ToString());
        if (score_value == 5 & consequtive_ques_no == 0)
        {
            file_score++;
            consequtive_ques_no = 5; score_value = 0;
            File.WriteAllText(File_path, file_score.ToString());
            LoadScene("scene3_congratulation");
        }
        else if (score_value < 5 & consequtive_ques_no == 0)
        {

            consequtive_ques_no = 5; score_value = 0;
            File.WriteAllText(File_path, file_score.ToString());
            LoadScene("scene4_tryagain_update");
        }
        else
        {
            value1 = Random.Range(1, 10);
            value2 = Random.Range(1, 10);

            if (value1 > value2)
            {
                //Question.text
                string question = "  " + value1 + " - " + value2 + "  = ?";
                Debug.Log(question);
                StartCoroutine(DisplayTextPanel(question));
                answer = value1 - value2;
            }
            else
            {
                //Question.text
                string question = "  " + value2 + " - " + value1 + "  = ?";
                Debug.Log(question);
                StartCoroutine(DisplayTextPanel(question));
                answer = value2 - value1;
            }
            int i = Random.Range(1, 4);
            int ans1, ans2, ans3;
            if (i == 1)
            {
                Answer1.text = answer + "";
                 ans1 = Random.Range(1, 10);
                 ans2= Random.Range(1, 10);
                ans3 = Random.Range(1, 10);
                while (answer == ans1)
                {
                    ans1 = Random.Range(1, 10);
                }
                Answer2.text = ans1.ToString();// Random.Range(1, 10) + "";
                while (answer == ans2 || ans2==ans1)
                {
                    ans2 = Random.Range(1, 10);
                }
                Answer3.text = ans2.ToString(); // Random.Range(1, 10) + "";
                while(answer == ans3 || ans3 == ans2||ans3==ans1)
                {
                    ans3 = Random.Range(1, 10);
                }
                Answer4.text = ans3.ToString();
            }
            else if (i == 2)
            {
                Answer2.text = answer + "";
                ans1 = Random.Range(1, 10);
                ans2 = Random.Range(1, 10);
                ans3 = Random.Range(1, 10);
                while (answer == ans1)
                {
                    ans1 = Random.Range(1, 10);
                }
                Answer1.text = ans1.ToString();// Random.Range(1, 10) + "";
                while (answer == ans2 || ans2 == ans1)
                {
                    ans2 = Random.Range(1, 10);
                }
                Answer3.text = ans2.ToString();// Random.Range(1, 10) + "";
                while (answer == ans3 || ans3 == ans2 || ans3 == ans1)
                {
                    ans3 = Random.Range(1, 10);
                }
                Answer4.text = ans3.ToString();

            }
            else if(i== 3) 
            {
                Answer3.text = answer + "";
                ans1 = Random.Range(1, 10);
                ans2 = Random.Range(1, 10);
                ans3 = Random.Range(1, 10);
                while (answer == ans1)
                {
                    ans1 = Random.Range(1, 10);
                }
                Answer2.text = ans1.ToString();// Random.Range(1, 10) + "";
                while (answer == ans2 || ans2 == ans1)
                {
                    ans2 = Random.Range(1, 10);
                }
                Answer1.text = ans2.ToString();// Random.Range(1, 10) + "";
                while (answer == ans3 || ans3 == ans2 || ans3 == ans1)
                {
                    ans3 = Random.Range(1, 10);
                }
                Answer4.text = ans3.ToString();

            }
            else
            {
                Answer4.text = answer + "";
                ans1 = Random.Range(1, 10);
                ans2 = Random.Range(1, 10);
                ans3 = Random.Range(1, 10);
                while (answer == ans1)
                {
                    ans1 = Random.Range(1, 10);
                }
                Answer2.text = ans1.ToString();// Random.Range(1, 10) + "";
                while (answer == ans2 || ans2 == ans1)
                {
                    ans2 = Random.Range(1, 10);
                }
                Answer1.text = ans2.ToString();// Random.Range(1, 10) + "";
                while (answer == ans3 || ans3 == ans2 || ans3 == ans1)
                {
                    ans3 = Random.Range(1, 10);
                }
                Answer3.text = ans3.ToString();

            }

        }





    }
    public void FixedUpdate()
    {
        Monster.position = Vector3.MoveTowards(Monster.position, Dog.position, speed);
        float distance = Vector3.Distance(Monster.position, Dog.position);
       // Debug.Log(distance);
       /* if (distance <= 100)
        {
          //  LoadScene("scene4_tryagain_update");
        }*/
    }

    public void CheckAnswer(Button button_colour)
    {
        TextMeshProUGUI button_answer = button_colour.GetComponentInChildren<TextMeshProUGUI>();
        Image image = button_colour.GetComponent<Image>();
        if (button_answer.text == answer.ToString())
        {
            StartCoroutine(ChangeColorCoroutine(button_colour, Color.green));
            ThrowObject();


            if (consequtive_ques_no != 0)
            {
                consequtive_ques_no--;
                score_value++;

               // Debug.Log("start wait");
                StartCoroutine(ResetThrowCooldownStart());
               // Debug.Log("end wait");

            }


        }
        else
        {


            if (consequtive_ques_no != 0)
            {
                consequtive_ques_no--;
                StartCoroutine(ChangeColorCoroutine(button_colour, Color.red));
                QuestionGenerate();
            }

        }
        progress++;
        slider_value.value = progress;


    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    public void ThrowObject()
    {


        // Create a new instance of the object to throw
        Vector3 newPos = new Vector3((Fruitposition.position.x - 1920) / 1, (Fruitposition.position.y - 1080) / 1, 0);
        
        Debug.Log("actual_position"+Fruitposition.position);
        Debug.Log("new_position"+newPos);
        GameObject FruiteClone = Instantiate(Fruit, newPos, Quaternion.identity);
        FruiteClone.transform.SetParent(parentCanvas, false);
        Debug.Log(FruiteClone.name);
        Debug.Log("clone position:");
        Debug.Log(FruiteClone.transform.position);
        // Calculate the direction from the monster to the target
        Vector3 direction = (Monster.position - Dog.position).normalized;
        Rigidbody2D rb = FruiteClone.GetComponent<Rigidbody2D>();
        // Apply force to the monster in that direction
        rb.AddForce(Vector3.up * 400.0f, ForceMode2D.Impulse);
        rb.AddForce(direction * 2500.0f, ForceMode2D.Impulse);
        //rb.AddForce(-Vector3.up * 200.0f, ForceMode2D.Impulse);

    }
    IEnumerator ResetThrowCooldownStart()
    {

        //Debug.Log(Time.time);
        yield return new WaitForSeconds(2.0f);
        QuestionGenerate();
        int randomIndex = Random.Range(0, imageOptions.Count);
        Monster.position = startPosition;
        Monster_obj.SetActive(true);
        imageComponent.sprite = imageOptions[randomIndex];

        //yield return new WaitForSeconds(1.0f);
       // Debug.Log(Time.time);



    }
    public IEnumerator DisplayTextPanel(string text)
    {
        Question.text = "";
        foreach (char item in text.ToCharArray())
        {
            Question.text += item;
            yield return new WaitForSeconds(0.04f);
        }
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
}

