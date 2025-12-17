using UnityEngine.Playables;

// PlayableBehaviour は Timeline 再生時に呼ばれる挙動を定義
public class UIFadeSoundPlayableBehaviour : PlayableBehaviour {

    // フェード対象の UIFadeSound コンポーネント
    public UIFadeSound target;

    // フェードの種類（IN / OUT）
    public UIFadeSound.FadeType fadeType = UIFadeSound.FadeType.FadeIn;

    // フェードにかける時間
    public float fade = 1f;

    // 二重実行防止フラグ
    private bool played = false;

    public override void OnBehaviourPlay( Playable playable , FrameData info )
    {
        // target が無いか、すでに実行していたら実行しない
        if ( target == null || played )
            return;

        // TimelineClip 開始時にメインのスクリプト本体のフェードを実行
        target.PlayFade( fadeType , fade );

        // 二度呼ばれないようにBlockする
        played = true;
    }

    public override void OnBehaviourPause( Playable playable , FrameData info )
    {
        // 次のクリップで実行できるようフラグをリセット
        played = false;
    }
}
