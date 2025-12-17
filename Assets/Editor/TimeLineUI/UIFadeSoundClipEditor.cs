#if UNITY_EDITOR
using UnityEditor.Timeline;
using UnityEngine.Timeline;
using UnityEngine;

[CustomTimelineEditor( typeof( UIFadeSoundClip ) )]
public class UIFadeSoundClipEditor : ClipEditor
{
    public override void OnClipChanged( TimelineClip clip )
    {
        // Clip の asset を取得
        var asset = clip.asset as UIFadeSoundClip;
        if ( asset == null )
            return;

        // 現在の TimelineClip の duration を取り出す
        float newDuration = (float)clip.duration;

        // asset.fade と clip.duration が異なる場合は、fade に duration を反映
        // → Clip 長さ変更時に自動でフェード時間も同期させるため
        if ( Mathf.Abs( asset.fade - newDuration ) > 0.001f ) {
            asset.fade = newDuration;
        }
    }
}
#endif