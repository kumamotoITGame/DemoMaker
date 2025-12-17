using UnityEngine.Timeline;

[TrackColor( 0.3f , 0.8f , 1f )]
[TrackBindingType( typeof( UIFadeSound ) )]
public class UIFadeSoundTrack : TrackAsset {
    
    protected override void OnCreateClip( TimelineClip clip )
    {
        base.OnCreateClip( clip );

        // クリップ作成時のデフォルト duration 設定
        clip.duration = 1.0;
    }

}

