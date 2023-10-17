using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class musicmanagement : MonoBehaviour
{
    [SerializeField] Image soundIcon;
    [SerializeField] Image soundoffIcon;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }
    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        save();
        UpdateButtonIcon();
    }
    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundIcon.enabled = true;
            soundoffIcon.enabled = false;
        }
        else
        {
            soundIcon.enabled = false;
            soundoffIcon.enabled = true;

        }
    }

    public void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1; 
    }

    private void save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
