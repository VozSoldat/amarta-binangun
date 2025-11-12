using UnityEngine;

// Memastikan komponen AudioSource ada
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    private AudioSource musicSource;

    private const string MUSIC_KEY = "MusicEnabled";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        musicSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        LoadMusicState();
    }

    private void LoadMusicState()
    {
        int enabled = PlayerPrefs.GetInt(MUSIC_KEY, 1);

        musicSource.mute = (enabled == 0);
    }

    public void SetMusicEnabled(bool isEnabled)
    {
        musicSource.mute = !isEnabled;

        PlayerPrefs.SetInt(MUSIC_KEY, isEnabled ? 1 : 0);
        
        PlayerPrefs.Save();
    }

    public bool IsMusicEnabled()
    {
        return !musicSource.mute;
    }
}