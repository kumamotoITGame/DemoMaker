#if UNITY_EDITOR
using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]  // Editor 起動時に自動で登録
public static class EditorPeriodicRunner
{
    static float lastTime = 0f;
    static float interval = 60f; // 秒単位

    // 静的コンストラクタで登録
    static EditorPeriodicRunner()
    {
        EditorApplication.update += Update;
    }

    static void Update()
    {
        float time = (float)EditorApplication.timeSinceStartup;

        // interval 秒ごとに処理
        if ( time - lastTime >= interval ) {
            lastTime = time;
            DoSomething();
        }
    }

    static void DoSomething()
    {
        // Editor 上で行いたい処理

    }


}
#endif
