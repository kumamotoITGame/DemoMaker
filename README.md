# DemoMaker

■■　Unityタイムラインを使った動画編集projectです　■■
＜＜Unityバージョン：2023.2.22f1＞＞

■元素材動画はWindows11の Windowsキー+ALT+R で動画を取っておいてください。
　動画編集する前に元素材を Windows11の機能の 「Windowsキー+ALT+R」 で動画を取っておいてください。

■開き方：
　初回のみ、UnityHubで　追加＞ディスクから加える　から　DemoMakerフォルダを指定して起動

■起動後：
　Project の Assets>Timeline の Timelineをダブルクリック
　Timelineウインドウが開き、そこで動画編集を行います
　

　※Timelineに Recorder Trackがない場合
　　　UnituyEditor.Recorder.Timeline の Recorder.Track を追加
　　　トラックに RecorderClip を追加（緑のアンダーラインの箱が出ます)


　 Recorder Track のinspector　で設定
           Selected recorder:Movie
///////// Recorder Clip の設定内容 //////////
Recorder Clip
    Selected recorder:Movie

  Input
    Source:Game View
    Output Resolution:FHD - 1080p
    Aspect Ratio:16:9 (1.7778)

Output Format
  Encoder:Unity Media Encoder
  Codec:H.264 MP4
  Encoding quality:High
  Include audio:true

Output File

File Name:<Recorder>_<Take>
Path:Project Recordings
/////////////////////////////////////////////


■動画編集
　Timelineの使い方
  　+ボタンで主に使うトラック
　　　「Control Track」：ヒエラルキー上のオブジェクトをアクティブにする

　Hierarchyでオブジェクトの追加の方法
　　　+ボタンから【MovieMake】Audio　　　　・・・　*.mp3
　　　+ボタンから【MovieMake】Movie　　　　・・・　*.mp4
　　　+ボタンから【MovieMake】UI_Image　　 ・・・　*.psd(Sprite)

　UIなどの画像レイアウトは授業で習ったようにScene上で編集してください


■録画方法
　このRecorder.Trackがある状態でUnity再生ボタンを押すと録画が開始されます
　動画データは Pathの「…」をクリックするとWindowsエディターが開き、書き出しデータを確認できます。
　※この録画中は音声が出ませんが、録画の方には音声が記録されています。
　　音声を確認したい、又は、録画しない場合はトラックの目のアイコンを斜線状態にし、録画機能を切ってください。

　プレイを解除するとその時点までの録画が記録されます


Unityで組んだものがそのまま動画撮りできるものなので、必要な機能はC#で拡張してみてください。





　　「Playable Track」 ：Add Form UI Fade Sound と合わせて使うと　UI Fade Sound のvolumeフェードインとアウトを指定できる

　　
