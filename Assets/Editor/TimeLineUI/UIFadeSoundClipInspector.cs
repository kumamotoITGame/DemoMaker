#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[CustomEditor( typeof( UIFadeSoundClip ) )]
public class UIFadeSoundClipInspector : Editor
{
    public override void OnInspectorGUI()
    {
        // serializedObject を更新
        serializedObject.Update();

        // fade / fadeType と target の描画
        EditorGUILayout.PropertyField( serializedObject.FindProperty( "fadeType" ) );
        EditorGUILayout.PropertyField( serializedObject.FindProperty( "target" ) );
        // fade プロパティ
        var fadeProp = serializedObject.FindProperty( "fade" );
        //EditorGUILayout.PropertyField( fadeProp );

        // fade の変更を監視する
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField( fadeProp );
        if ( EditorGUI.EndChangeCheck() ) {
            // fade が変更されたら serializedObject を反映
            serializedObject.ApplyModifiedProperties();

            // Inspector 上の fade 値を元に TimelineClip の長さを更新したい
            UIFadeSoundClip clipAsset = (UIFadeSoundClip)target;
            float duration = fadeProp.floatValue;

            // 同じ asset を使う全 TimelineClip を探して duration を更新
            UpdateAllTimelineClips( clipAsset , duration );
        }
        else {
            serializedObject.ApplyModifiedProperties();
        }
    }

    // 同じ UIFadeSoundClip asset を使用しているすべての TimelineClip を探して duration を更新する
    void UpdateAllTimelineClips( UIFadeSoundClip asset , float duration )
    {
        // シーン内のすべての PlayableDirector を検索
        foreach ( var director in GameObject.FindObjectsByType<PlayableDirector>( FindObjectsSortMode.None ) ) {
            if ( director.playableAsset is TimelineAsset timeline ) {
                // Timeline 内のすべての Track から clips を調べる
                foreach ( var track in timeline.GetOutputTracks() ) {
                    foreach ( var clip in track.GetClips() ) {
                        // 同じ asset を使っている clip を発見した場合 duration を変更
                        if ( clip.asset == asset ) {
                            clip.duration = duration;
                        }
                    }
                }
            }
        }
    }
}
#endif