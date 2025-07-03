using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;
    public AudioClip buttonSFX;

    public AudioClip jumpscareSFX;

    public AudioSource heartbeatPlayer; //seperate audiosource player for heartbeat

    private AudioSource audioPlayer;



    void Awake()
    {
        //makes sure that there's only one sound manager
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayButton()
    {
        audioPlayer.PlayOneShot(buttonSFX);

    }

    public void PlayJumpscare()
    {
        audioPlayer.PlayOneShot(jumpscareSFX);

    }


    public void PlayMusic()
    {
        audioPlayer.Play();
    }

    public void StopMusic()
    {
        audioPlayer.Stop();
    }

    public void PlayHeartbeat()
    {
        heartbeatPlayer.Play();
    }
    public void StopHeartbeat()
    {
        heartbeatPlayer.Stop();
    }


}

