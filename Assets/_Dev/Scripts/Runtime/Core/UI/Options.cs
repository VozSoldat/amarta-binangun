using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject musicOnButton;
    public GameObject musicOffButton;
    public GameObject sfxOnButton;
    public GameObject sfxOffButton;
    public void TurnOffMusic()
    {
        MusicManager.Instance.SetMusicEnabled(false);
        MusicManager.Instance.IsMusicEnabled();
        musicOffButton.SetActive(true);
        musicOnButton.SetActive(false);
    }
    public void TurnOnMusic()
    {
        MusicManager.Instance.SetMusicEnabled(true);
        MusicManager.Instance.IsMusicEnabled();
        musicOffButton.SetActive(false);
        musicOnButton.SetActive(true);
    }
    public void TurnOffSFX()
    {
        sfxOffButton.SetActive(true);
        sfxOnButton.SetActive(false);
    }
    public void TurnOnSFX()
    {
        sfxOffButton.SetActive(false);
        sfxOnButton.SetActive(true);
    }
}