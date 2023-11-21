using UnityEngine;
using UnityEngine.UI;
using Microsoft.AppCenter.Unity.Analytics;

public class MusicManagement : MonoBehaviour
{
    [SerializeField] Image soundIcon;
    [SerializeField] Image soundoffIcon;
    private bool muted = false;

    void Start()
    {
        Load();
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        muted = !muted; // Toggle the muted state
        AudioListener.pause = muted;
        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        soundIcon.enabled = !muted;
        soundoffIcon.enabled = muted;
    }

    public void Load()
    {
        muted = PlayerPrefs.GetInt("muted", 0) == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic here
    }
}
