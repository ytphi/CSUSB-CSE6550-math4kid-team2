using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Microsoft.AppCenter.Unity.Analytics;
public class pause_resume : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PausePanel;
    
    // Update is called once per frame
    void Update()
    {

    }
    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
   

    
    


}
