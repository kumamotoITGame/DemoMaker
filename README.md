# DemoMaker

■■　Unity Timeline 動画編集プロジェクト（DemoMaker）　■■

本プロジェクトは、Unity Timeline を使用した動画編集用プロジェクトです。
Unity 上で構築した演出を、そのまま動画として書き出すことができます。

■ 使用環境
Unity バージョン：2023.2.22f1
OS：Windows 11

■ 元素材動画の準備
動画編集を行う前に、Windows 11 の画面録画機能を使用して
編集用の元動画を準備してください。
録画開始：Windowsキー + ALT + R
録画した動画（*.mp4）を Unity に取り込みます

■ プロジェクトの開き方（初回のみ）
1.Unity Hub を起動
2.追加 → ディスクから加える を選択
3.DemoMaker フォルダを指定してプロジェクトを開く

▶ 起動後の操作手順
1.Project ウィンドウから以下を開きます
　　Assets > Timeline > Timeline
2.Timeline を ダブルクリック
3.Timeline ウィンドウが開き、動画編集が可能になります

⏺ Recorder Track がない場合の設定
　Timeline に Recorder Track が存在しない場合は、以下の手順で追加してください。
　Recorder Track の追加手順
　　1.Timeline の「＋」ボタンをクリック
　　2.UnityEditor.Recorder.Timeline を選択
　　3.Recorder Track を追加
　　4.Recorder Track に Recorder Clip を追加
　　　・緑色のアンダーライン付きクリップが表示されます

⚙ Recorder Clip 設定（推奨）
Recorder Clip
・Selected Recorder：Movie

Input
・Source：Game View
・Output Resolution：FHD - 1080p
・Aspect Ratio：16:9（1.7778）

Output Format
・Encoder：Unity Media Encoder
・Codec：H.264 MP4
・Encoding Quality：High
・Include Audio：true

Output File
・File Name：<Recorder>_<Take>
・Path：Project Recordings

🎞 動画編集（Timeline の使い方）
よく使うトラック
・Control Track
　ヒエラルキー上のオブジェクトを
　アクティブ／非アクティブに制御します

🧩 Hierarchy へのオブジェクト追加方法
　Hierarchy の「＋」ボタンから、以下のオブジェクトを追加できます。
　　MovieMake / Audio	音声ファイル（*.mp3）
　　MovieMake / Movie	動画ファイル（*.mp4）
　　MovieMake / UI_Image	画像（*.psd / Sprite）

※ UI や画像のレイアウトは、授業で学んだ方法と同様に
Scene ビュー上で編集してください。


 

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

　　
