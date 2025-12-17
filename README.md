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

■ ※ Unity UI と Recorder の追加（必要）
　Window > Pakage Manager 
　Unity Registry より
　・Unity UI
　・Recorder
　の二つを検索して Install

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

🔴 録画方法
1.Recorder Track が有効な状態で Unity の ▶ 再生ボタンを押す
2.再生と同時に録画が開始されます
3.Recorder の Path の「…」 をクリックすると
　Windows エクスプローラーで出力先を確認できます

注意事項
・録画中は Unity 上では音声が再生されません
・書き出された動画には 音声は正常に記録されます
・録画しない場合や音声確認をしたい場合は
　Recorder Track の 目のアイコンをオフ にしてください
※ 再生を停止した時点までの内容が動画として保存されます。

 

