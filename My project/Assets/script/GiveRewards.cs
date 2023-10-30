using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.U2D;

public class GiveRewards : MonoBehaviour
{
    public Image starImage;
    public List<Sprite> spriteOptions = new List<Sprite>();

    void Start()
    {
        SetStar(); // You may want to call SetStar() in Start if it should be set when the scene starts.
    }

    public void SetStar()
    {
        int score = PlayerPrefs.GetInt("Scoredata", 0);
        Debug.Log("Score: " + score);

        if (score == 5)
        {
            starImage.sprite = spriteOptions[0];
        }
        else if (score == 4)
        {
            starImage.sprite = spriteOptions[1];
        }
        else
        {
            starImage.sprite = spriteOptions[2];
        }

        // Log to check the sprite and options
        Debug.Log("Selected Sprite: " + starImage.sprite.name);
    }
}
