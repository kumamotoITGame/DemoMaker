using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

//[RequireComponent( typeof( RawImage ) )]
public class VideoFade : MonoBehaviour
{
    public VideoClip videoClip; // 再生したい動画
    public float fade = 2f;   // フェード時間（秒）

    private RawImage rawImage;
    private VideoPlayer videoPlayer;
    private Material videoMaterial;

    void OnEnable()
    {
        rawImage = GetComponent<RawImage>();

        // 動画を表示するための RenderTexture を作成
        RenderTexture rt = new RenderTexture( (int)videoClip.width , (int)videoClip.height , 0 , RenderTextureFormat.ARGB32 );
        rt.Create();

        // VideoPlayer を動的作成
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.clip = videoClip;
        videoPlayer.isLooping = true;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = rt;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.None;
        videoPlayer.Play();

        // RawImage に RenderTexture をセット
        rawImage.texture = rt;

        // マテリアルをコピーしてフェード用に設定
        Shader shader = Shader.Find( "UI/Unlit/Transparent" );
        videoMaterial = new Material( shader );
        videoMaterial.mainTexture = rt;
        rawImage.material = videoMaterial;

        // フェードイン開始
        StartCoroutine( FadeIn() );
    }

    IEnumerator FadeIn()
    {
        float t = 0f;
        while ( t < fade ) {
            t += Time.deltaTime;
            float alpha = Mathf.Clamp01( t / fade );
            videoMaterial.color = new Color( 1f , 1f , 1f , alpha );
            yield return null;
        }
        videoMaterial.color = Color.white;
    }

    public void FadeOut()
    {
        StartCoroutine( FadeOutCoroutine() );
    }

    IEnumerator FadeOutCoroutine()
    {
        float t = 0f;
        Color startColor = videoMaterial.color;
        while ( t < fade ) {
            t += Time.deltaTime;
            float alpha = Mathf.Clamp01( 1f - t / fade );
            videoMaterial.color = new Color( 1f , 1f , 1f , alpha );
            yield return null;
        }
        videoMaterial.color = new Color( 1f , 1f , 1f , 0f );
        videoPlayer.Stop();
    }
}

