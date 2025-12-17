using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof( Image ) )]
public class UIFadeSound : SoundControl {

    public enum FadeType {
        FadeIn,
        FadeOut
    }


    [Header( "UI Fade Settings" )]
    public Sprite sprite;
    Image image;
    public float fade = 0.0f;

    private float time;
    private bool isPlaying = false;

    private FadeType currentType = FadeType.FadeIn;

    public bool standalone = true; 

    Color c ;

    int oneShotcount = 0;

    void OnValidate()
    {
        SetUp();
    }


   /*void Reset()
    {
        canvasGroup = GetComponent<Image>();
    }*/

    public void PlayFade()
    {
        if( image == null )
            return;

        time = 0f;
        isPlaying = true;

        // 音を鳴らす（継承元の処理）
        if( audioSource != null )
        {
            audioSource.Play();
        }

    }

    private void Awake()
    {
        if(standalone)
        {
            PlayFade();
        }
            gameObject.SetActive( false );
    }


    void OnEnable()
    {
        audioSource.volume = volume;
        audioSource.playOnAwake = false;

        if( audio )
            audioSource.PlayOneShot( audio );

        if( image != null )
        {
            c = image.color;
            image.color = new Color( c.r , c.g , c.b , 0.0f);
        }

    }

    void Update()
    {
        base.Update(); // SoundControl の Update（音量調整）

        if( !isPlaying || image == null )
            return;

        time += Time.deltaTime;

        float t=1;
        if( fade > 0.0f )
        {
            t = Mathf.Clamp01( time / fade );
        }



        Color c = image.color;

        if( standalone )
        {
            image.color = new Color( c.r , c.g , c.b , t );  // 透明からスタート
        }
        else
        {
            if( currentType == FadeType.FadeIn )
                image.color = new Color( c.r , c.g , c.b , t );  // 透明からスタート
            else
                image.color = new Color( c.r , c.g , c.b , ( 1f - t ) );  // 不透明からスタート
        }

        if( t >= 1f )
            isPlaying = false;
    }

    void SetUp()
    {
        base.SetUp();

        if( image == null )
        {
            image = GetComponent<Image>();
        }
        if( image.sprite == null )
        {
            image.sprite = sprite;
        }
    }

    /// <summary>
    /// フェード実行（フェードイン/アウト）
    /// </summary>
    public void PlayFade( FadeType type , float duration = -1f )
    {

        if( standalone )
            return;


        gameObject.SetActive( true );

        if( image == null )
            SetUp();

        currentType = type;
        time = 0f;
        isPlaying = true;

        if( duration > 0f )
            fade = duration;

        // 初期値セット
        Color c = image.color;
        if( type == FadeType.FadeIn )
            image.color = new Color( c.r , c.g , c.b , 0f );  // 透明からスタート
        else
            image.color = new Color( c.r , c.g , c.b , 1f );  // 不透明からスタート
    }

}
