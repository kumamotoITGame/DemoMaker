#if UNITY_EDITOR
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[InitializeOnLoad]
public static class ComponentAutoAdder
{
    static ComponentAutoAdder()
    {
        // Hierarchy が変わるたびに呼ばれる
        EditorApplication.hierarchyChanged += OnHierarchyChanged;
    }

    private static void OnHierarchyChanged()
    {
        AddRawImage();
    }

    static void AddRawImage()
    {
        // シーン上のすべての RawImage を取得
        RawImage[] raws = Object.FindObjectsOfType<RawImage>( true );

        /*
        // 非アクティブなGameObjectは対象にしない、順序不定でシーン上に存在するTextMeshProUGUIコンポーネントを全て取得する
        RawImage[] textMeshProUGUIs1 = FindObjectsByType<RawImage>( FindObjectsSortMode.None );

        // 非アクティブなGameObjectも対象にした、InstanceIDでソートされた、全てのシーン上に存在するTextMeshProUGUIコンポーネントを取得する
        TextMeshProUGUI[] textMeshProUGUIs2 = FindObjectsByType<RawImage>( FindObjectsInactive.Include , FindObjectsSortMode.InstanceID );

        // 非アクティブなGameObjectは対象にしない、順序不定でシーン上に存在するTextMeshProUGUIコンポーネントを全て取得する
        Object[] textMeshProUGUIs3 = FindObjectsByType( typeof( RawImage ) , FindObjectsSortMode.None );

        // 非アクティブなGameObjectも対象にした、InstanceIDでソートされた、全てのシーン上に存在するTextMeshProUGUIコンポーネントを取得する
        Object[] textMeshProUGUIs4 = FindObjectsByType( typeof( RawImage ) , FindObjectsInactive.Include , FindObjectsSortMode.InstanceID );
        */

        foreach ( var raw in raws ) {
            // VideoToCanvas がアタッチされていなければ追加
            if ( raw.gameObject.GetComponent<VideoToCanvas>() == null ) {
                Undo.AddComponent<VideoToCanvas>( raw.gameObject ); // Undo 対応
                Debug.Log( $"VideoToCanvas を自動追加: {raw.gameObject.name}" );
            }
        }
    }


}
#endif
