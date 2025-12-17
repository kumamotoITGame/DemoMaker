#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEditor.Recorder;
using UnityEditor.Recorder.Timeline;
using System.Collections;

[ExecuteAlways]
public class TimelineRecorderClipController : MonoBehaviour
{
    public PlayableDirector director;

    private RecorderClip recorderClip;
    private RecorderSettings recorderSettings;
    private bool isStopping = false;

    void OnEnable()
    {
        if ( director == null )
            director = GetComponent<PlayableDirector>();
        if ( director == null )
            return;

        TimelineAsset timeline = director.playableAsset as TimelineAsset;
        if ( timeline == null )
            return;

        // RecorderTrack を探す
        foreach ( var track in timeline.GetOutputTracks() ) {
            if ( track is RecorderTrack recorderTrack ) {
                // 最初のクリップを取得
                if ( recorderTrack.GetClips() != null ) {
                    foreach ( var clip in recorderTrack.GetClips() ) {
                        recorderClip = clip.asset as RecorderClip;
                        if ( recorderClip != null ) {
                            recorderSettings = recorderClip.settings;
                            break;
                        }
                    }
                }
                break;
            }
        }

        if ( recorderSettings != null ) {
            // 出力解像度を FHD 1080p に変更
            if ( recorderSettings is MovieRecorderSettings movieSettings ) {
//ここで設定できるかな？
            }
        }

        // 再生開始
        if ( director != null )
            director.played += OnDirectorPlayed;
    }

    private void OnDisable()
    {
        if ( director != null )
            director.played -= OnDirectorPlayed;
    }

    private void OnDirectorPlayed( PlayableDirector dir )
    {
        if ( !isStopping ) {
            StartCoroutine( CheckClipEnd() );
        }
    }

    private IEnumerator CheckClipEnd()
    {
        isStopping = true;

        double clipEndTime = 0;
        if ( recorderClip != null )
//このあたりでクリップの終わりの時間をチェックできる？

        while ( director.time < clipEndTime ) {
            yield return null;
        }

        director.Stop();
        isStopping = false;
        Debug.Log( "Recorder Clip 再生終了 → Director 停止" );
    }
}
#endif
