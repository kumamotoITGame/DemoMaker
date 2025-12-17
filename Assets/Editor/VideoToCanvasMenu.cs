#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class VideoToCanvasMenu
{
    [MenuItem( "GameObject/【MovieMake】/Movie" , false , 10 )]
    private static void CreateRawImageWithVideoToCanvas( MenuCommand menuCommand )
    {
        // RawImage を作成
        GameObject go = new GameObject( "Movie" , typeof( RectTransform ) , typeof( CanvasRenderer ) , typeof( RawImage ) );

        // VideoToCanvas コンポーネントを追加
        go.AddComponent<VideoToCanvas>();

        go.GetComponent<RectTransform>().sizeDelta = new Vector2(1920f,1080f);

        // 親を Canvas に設定（もし選択されていれば）
        GameObject parent = menuCommand.context as GameObject;
        if ( parent != null && parent.GetComponent<Canvas>() != null ) {
            GameObjectUtility.SetParentAndAlign( go , parent );
        }
        else {
            // 選択されていない場合、シーンに Canvas を探す
            Canvas canvas = Object.FindObjectOfType<Canvas>();
            if ( canvas != null ) {
                GameObjectUtility.SetParentAndAlign( go , canvas.gameObject );
            }
        }

        // Undo に対応
        Undo.RegisterCreatedObjectUndo( go , "Create RawImage with VideoToCanvas" );

        // 選択状態にする
        Selection.activeGameObject = go;
    }
}
#endif
