MV*なToDoアプリ
=====

MV*なアーキテクチャーの習作として作成したToDoアプリケーションです。

## Model

`ToDoModel`プロジェクトとして独立して作成し、テストは`ToDoModel.Test`プロジェクトで行っています。

以下の記事を元に、変更通知プロパティと戻り値のないメソッドで構成されています。

[MVVMのModelにまつわる誤解 - the sea of fertility](http://ugaya40.hateblo.jp/entry/model-mistake)

## アプリ

- WinForms  
  `ToDoFormApp`プロジェクトでMVPとして作っています。Presenterのテストは`ToDoFormApp.Test`プロジェクトで行っています。
