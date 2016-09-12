ToDoリスト
=====

このプログラムは新入社員研修の「実習：プログラミング」のサンプルプログラムである。

## ToDo

### アプリの機能

- [ ] ToDoリストにタスク内容を指定してタスクを追加できる
- [ ] ToDoリストのタスクの件数を取得できる
- [ ] タスクの完了状態を設定できる
- [ ] ToDoリストの完了タスク件数を取得できる
- [ ] 指定した位置のタスクを削除できる
- [ ] 初期状態ではタスクは登録されていない
- [ ] タスク内容を指定して同一タスクの有無を判断できる
- [ ] タスクをクリアできるか判断できる

### アプリの見た目

- タイトルバーにタスク件数が表示される
- 追加ボタンを押すと入力したタスクが登録できる
  - 入力したタスクと同じタスクが登録されていたら確認メッセージを表示する
    - はいを押したら登録する
    - いいえを押したら中断する
- チェックボックスをクリックするとタスクの完了状態を切り替えられる
- 削除ボタンを押すとその行のタスクを削除できる
- Spaceキーを押すとカーソル行の完了状態を切り替えられる
- Deleteキーを押すとカーソル行のタスクを削除できる
- 起動直後のタスクリストは空である
- クリアボタンを押すとタスクを空にできる
    - タスクが登録されていなければエラーメッセージを表示して中断する
- 画面サイズの変更に追従して画面項目も拡縮される
