using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent( typeof( VideoPlayer ) )]
public class VideoToCanvas : MonoBehaviour
{
    
    //public string videoPath;    // StreamingAssets などから読み込む場合
    public VideoClip videoClip;   // 直接アサインも可能
    public float rawVdeoStartTime;
    public float fadeIn = 0.0f;   // フェード時間
    public bool soundMute = false;

    private RawImage targetUI;     // Canvas 上の RawImage
    private VideoPlayer videoPlayer;
    private RenderTexture renderTexture;
    private Material videoMaterial;

#if UNITY_EDITOR
    void OnInspectorGUI()
    {
        SetUp();
    }
#endif
    void OnValidate()//OnInspectorGUI()//OnValidate()
    {
        SetUp();
    }

    void OnEnable()
    {

        //Cursor.visible = false;

        targetUI = GetComponent<RawImage>();
        Shader shader = Shader.Find( "UI/Unlit/Transparent" );
        videoMaterial = new Material( shader );
        targetUI.material = videoMaterial;


        // VideoPlayer を動的に追加
        SetUp();
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = true;

        videoPlayer.SetDirectAudioMute( 0 , soundMute );

        // RenderTexture をスクリプトで作成
        /*
         * ARGB32（標準フルカラー）UI・動画再生・一般用途
         * ARGBHalf（16bit半精度 ×4）（高画質）	HDR / 色再生精度が必要な画像処理
         * ARGBFloat（32bit浮動小数 ×4）（超高画質）	物理ベース処理・VFX・高度画像処理
         */
        renderTexture = new RenderTexture( 1920 , 1080 , 0 , RenderTextureFormat.ARGBFloat );
        renderTexture.Create();

        // RawImage に表示させる
        targetUI.texture = renderTexture;

        // VideoPlayer の出力先を RenderTexture に設定
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTexture;

        // 動画の読み込み方法（Clip か URL）
        if ( videoClip != null ) {
            videoPlayer.clip = videoClip;
        }
        //else if ( !string.IsNullOrEmpty( videoPath ) ) {
        //    videoPlayer.url = videoPath; // 例: Application.streamingAssetsPath + "/demo.mp4";
        //}
        else {
            Debug.Log("動画ファイルがありません : "+gameObject.name);
        }

        if ( rawVdeoStartTime > 0.0f ) {
            // 読み込み完了後に再生
            videoPlayer.prepareCompleted += ( vp ) => {
                vp.time = rawVdeoStartTime; // rawVdeoTime秒から再生
                //vp.frame = rawVdeoFrame; // フレーム番号で指定
                vp.Play();
            };
            videoPlayer.Prepare();
        }
        else {

            // 読み込み完了後に再生
            videoPlayer.prepareCompleted += ( vp ) => vp.Play();
            videoPlayer.Prepare();
        }

        // フェードイン開始
        if ( fadeIn > 0.0f ) {
            StartCoroutine( FadeIn() );
        }

    }

    IEnumerator FadeIn()
    {
        float t = 0f;
        while ( t < fadeIn ) {
            t += Time.deltaTime;
            float alpha = Mathf.Clamp01( t / fadeIn );
            videoMaterial.color = new Color( 1f , 1f , 1f , alpha );
            yield return null;
        }
        videoMaterial.color = Color.white;
    }

    private void OnDestroy()
    {
        if ( renderTexture != null ) {
            renderTexture.Release();
        }
    }

    void SetUp()
    {
        if ( videoPlayer == null )
            videoPlayer = gameObject.GetComponent<VideoPlayer>();

        var scr =　gameObject.GetComponent<RectTransform>();
        scr.localPosition = Vector3.zero;
        scr.localRotation = Quaternion.identity;
        scr.localScale = Vector3.one;
        scr.pivot = new Vector2 ( 0.5f, 0.5f );
        scr.sizeDelta = new Vector2 ( 1920, 1080 );
        scr.anchorMax = new Vector2( 0.5f , 0.5f );
        scr.anchorMin = new Vector2( 0.5f , 0.5f );

    }

}
