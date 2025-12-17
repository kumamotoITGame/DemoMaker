#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor.Recorder;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineRecorderStopper : MonoBehaviour
{
    public PlayableDirector director;
    public RecorderController recorderController;

    private bool hasStopped = false;

    public List<RecorderController> runtimeControllers = new List<RecorderController>();


    void OnValidate()
    {
        SetUp();
    }

    private void Start()
    {
        SetUp();

        runtimeControllers.Clear();

        int sceneCount = SceneManager.sceneCount;
        for ( int i = 0 ; i < sceneCount ; i++ ) {
            Scene scene = SceneManager.GetSceneAt( i );
            if ( !scene.isLoaded )
                continue;

            foreach ( var root in scene.GetRootGameObjects() ) {
                runtimeControllers.AddRange( FindControllersInChildren( root ) );
            }
        }

        foreach ( var rc in runtimeControllers ) {
            //Debug.Log( $"Found RecorderController on {rc.gameObject.name} in scene {rc.gameObject.scene.name}" );
            recorderController = rc;
        }

    }

    private IEnumerable<RecorderController> FindControllersInChildren( GameObject go )
    {
        List<RecorderController> list = new List<RecorderController>();
        var rc = go.GetComponent<RecorderController>();
        if ( rc != null )
            list.Add( rc );

        foreach ( Transform child in go.transform ) {
            list.AddRange( FindControllersInChildren( child.gameObject ) );
        }

        return list;
    }


    void Update()
    {
        if ( hasStopped )
            return;
        if ( director == null || recorderController == null )
            return;

        // Timeline ÇÃçƒê∂Ç™èIóπÇµÇΩÇ©ämîF
        if ( director.state != PlayState.Playing || director.time >= director.duration ) {
            // Recorder í‚é~
            recorderController.StopRecording();
            hasStopped = true;
            Debug.Log( "Timeline ended Å® Recorder stopped" );
        }
    }

    void SetUp()
    {
        if ( director == null ) {
            // Scene ì‡ÇÃÇ∑Ç◊ÇƒÇÃ PlayableDirector
            PlayableDirector[] directors = Resources.FindObjectsOfTypeAll<PlayableDirector>();

            if ( directors != null && directors.Length > 0 ) {
            director = directors[0];
            }

        }


    }
}
#endif