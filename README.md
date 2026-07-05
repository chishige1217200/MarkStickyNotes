# MarkStickyNotes

MarkStickyNotes は、Markdown でメモを書きながらタスク管理もできる、Windows 向けの付箋アプリです。
通知領域（システムトレイ）に常駐し、必要なときに素早く付箋の追加・一覧表示・設定変更ができます。

## 主な機能

- 付箋の作成・編集・論理削除
- Markdown プレビュー（WebView2）
- 色、種別、担当者、状態、カテゴリー、優先度の管理
- 開始日・期限日の設定
- 付箋一覧での絞り込み検索（複数条件）
- 一覧の列ヘッダークリックによる昇順/降順ソート
- ドラッグ&ドロップで添付ファイルを保存し、Markdown リンクを自動挿入

## 技術スタック

- .NET 10 / Windows Forms
- Entity Framework Core + SQLite
- Markdig（Markdown 変換）
- WebView2（プレビュー表示）

## 動作環境

- Windows
- .NET 10 SDK
- WebView2 Runtime

## 起動方法

### ソースコードから起動する場合

1. 依存関係を復元

	dotnet restore

2. アプリを起動

	dotnet run --project MarkStickyNotes.csproj

初回起動時には、SQLite データベースのマイグレーションが自動適用されます。

### ビルド済みデータから起動する場合

1. Release から zip ファイルをダウンロード
2. zip ファイルを任意のフォルダに解凍
3. 解凍先の MarkStickyNotes.exe を実行

## データ保存先

- データベース: アプリ実行フォルダ配下の database.db
- 本文（Markdown）: アプリ実行フォルダ配下の contents フォルダ
- 添付ファイル: contents/<本文ファイル名>_files フォルダ

database.db 及び contents フォルダを削除すると、付箋データはすべて消去されます。

## アプリアイコン

https://www.flaticon.com/free-icon/markdown_17348486

<a href="https://www.flaticon.com/free-icons/markdown" title="markdown icons">Markdown icons created by Muhammad Andy - Flaticon</a>