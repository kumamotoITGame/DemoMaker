using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class UIFadeSoundClip : PlayableAsset, ITimelineClipAsset {

    // フェードの種類（FadeIn / FadeOut）
    public UIFadeSound.FadeType fadeType = UIFadeSound.FadeType.FadeIn;

    // フェードにかける時間（秒）＝ TimelineClip の duration と同期させる値
    public float fade = 1f;

    // 対象となる ヒエラルキー上の UIFadeSound を ExposedReference で参照
    public ExposedReference<UIFadeSound> target;

    // このクリップ自体には特に機能的な ClipCaps はない
    public ClipCaps clipCaps => ClipCaps.None;

    public override Playable CreatePlayable( PlayableGraph graph , GameObject owner )
    {
        // ScriptPlayable を作成し、PlayableBehaviour を取得
        var playable = ScriptPlayable<UIFadeSoundPlayableBehaviour>.Create( graph );
        var behaviour = playable.GetBehaviour();

        // Timeline の ExposedReference を実体に渡す
        behaviour.target = target.Resolve( graph.GetResolver() );
        // フェード情報を渡す
        behaviour.fadeType = fadeType;
        behaviour.fade = fade;

        return playable;
    }
}
