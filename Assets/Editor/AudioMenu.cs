#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public static class AudioMenu
{
    [MenuItem( "GameObject/yMovieMakez/Audio" , false , 10 )]
    private static void CreateAudioSourceWithControl( MenuCommand menuCommand )
    {
        // e‚ğ’T‚·: "Sound" ‚ª‚ ‚é‚©Šm”F
        GameObject parent = GameObject.Find( "Sound" );
        if ( parent == null ) {
            parent = new GameObject( "Sound" );
            Undo.RegisterCreatedObjectUndo( parent , "Create Sound Parent" );
        }

        // AudioSource + SoundControl ‚ğ‚ÂV‹K GameObject
        GameObject go = new GameObject( "Audio" , typeof( AudioSource ) );
        go.AddComponent<SoundControl>();
        go.GetComponent<AudioSource>().playOnAwake = false;
        go.GetComponent<AudioSource>().reverbZoneMix = 0.0f;

        // e‚Éİ’è
        GameObjectUtility.SetParentAndAlign( go , parent );

        // Undo “o˜^
        Undo.RegisterCreatedObjectUndo( go , "Create AudioSource with SoundControl" );

        // ‘I‘ğó‘Ô‚É
        Selection.activeGameObject = go;
    }
}
#endif
