using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;




public class Playwithsubtract : MonoBehaviour
{
    public int frame;
    public Transform Dog;
    public Transform Monster, parentCanvas, Fruitposition;
    public GameObject Fruit, Monster_obj;
    public float speed;
    public TextMeshProUGUI Question, Answer1, Answer2, Answer3, Score_text;
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
            LoadScene("scene4_tryagain");
        }
        else
        {
            value1 = Random.Range(1, 10);
            value2 = Random.Range(1, 10);

            if (value1 > value2)
            {
                //Question.text
                string question    = "  " + value1 + " - " + value2 + "  = ?";
                Debug.Log(question);
                StartCoroutine(DisplayText(question));
                answer = value1 - value2;
            }
            else
            {
                //Question.text
                string question= "  " + value2 + " - " + value1 + "  = ?";
                Debug.Log(question);
                StartCoroutine(DisplayText(question));
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
        float distance = Vector3.Distance(Monster.position, Dog.position);
        if (distance <= 0)
        {
            LoadScene("scene4_tryagain");
        }
    }

    public void CheckAnswer(TextMeshProUGUI button_answer)
    {
        if (button_answer.text == answer.ToString())
        {
            ThrowObject();
            

            if (consequtive_ques_no != 0)
            {
                consequtive_ques_no--;
                score_value++;

                Debug.Log("start wait");
                StartCoroutine(ResetThrowCooldown());
                Debug.Log("end wait");

            }


        }
        else
        {

            if (consequtive_ques_no != 0)
            {
                consequtive_ques_no--;
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
        Debug.Log(Fruitposition.position);
        Debug.Log(newPos);
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
    IEnumerator ResetThrowCooldown()
    {

        Debug.Log(Time.time);
        yield return new WaitForSeconds(2.0f);
        QuestionGenerate();
        int randomIndex = Random.Range(0, imageOptions.Count);
        Monster.position = startPosition;
        Monster_obj.SetActive(true);
        imageComponent.sprite = imageOptions[randomIndex];

        //yield return new WaitForSeconds(1.0f);
        Debug.Log(Time.time);



    }
    public IEnumerator DisplayText(string text)
    {
        Question.text = "";
        foreach (char item in text.ToCharArray())
        {
            Question.text += item;
            yield return new WaitForSeconds(0.04f);
        }
    }
}

