#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public static class UIMenu {
    [MenuItem( "GameObject/【MovieMake】/UI Image" , false , 10 )]
    private static void CreateAudioSourceWithControl( MenuCommand menuCommand )
    {

        // Image を作成
        GameObject go = new GameObject( "UI_Image" , typeof( RectTransform ) , typeof( Image ) , typeof( AudioSource ) );


        // 親を Canvas に設定（もし選択されていれば）
        GameObject parent = menuCommand.context as GameObject;
        if( parent != null && parent.GetComponent<Canvas>() != null )
        {
            GameObjectUtility.SetParentAndAlign( go , parent );
        }
        else
        {
            // 選択されていない場合、シーンに Canvas を探す
            Canvas canvas = Object.FindObjectOfType<Canvas>();
            if( canvas != null )
            {
                GameObjectUtility.SetParentAndAlign( go , canvas.gameObject );
            }
        }

        // UIFadeSound コンポーネントを追加
        go.AddComponent<UIFadeSound>();
        go.GetComponent<AudioSource>().playOnAwake = false;
        go.GetComponent<AudioSource>().reverbZoneMix = 0.0f;
 
        // 親に設定
        GameObjectUtility.SetParentAndAlign( go , parent );

        // Undo 登録
        Undo.RegisterCreatedObjectUndo( go , "Create MessageUI" );

        // 選択状態に
        Selection.activeGameObject = go;
    }
}
#endif
