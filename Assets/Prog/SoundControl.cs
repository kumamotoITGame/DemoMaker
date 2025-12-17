using UnityEngine;
using UnityEngine.Video;


[RequireComponent( typeof( AudioSource ) )]
public class SoundControl : MonoBehaviour
{
    [Header( "Sound Settings" )]
    public AudioClip audio;
    public float volume = 1.0f;
    protected AudioSource audioSource;

    void OnValidate()
    {
        SetUp();
    }

    // Start is called before the first frame update
    protected void OnEnable()
    {
        SetUp();

        
        audioSource.playOnAwake = false;

        audioSource.clip = audio;
        audioSource.reverbZoneMix = 0.0f;
        audioSource.Play( );
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if( audio == null )
            return;

        audioSource.volume = volume;
    }

    protected void SetUp()
    {
        if ( audioSource == null ) {
            audioSource = GetComponent<AudioSource>();
        }
    }
}
