ToDoリスト
=====

このプログラムは新入社員研修の「実習：プログラミング」のサンプルプログラムである。

## ToDo

### アプリの機能

- [x] ToDoリストにタスク内容を指定してタスクを追加できる
- [x] 追加直後タスクの完了状態は未完了
- [x] タスク内容が空では追加できない
- [x] ToDoリストのタスクの件数を取得できる
- [x] 初期状態ではタスク件数は0件
- [x] タスクを1件追加したら1件
- [x] タスクの完了状態を設定できる
- [x] ToDoリストの完了タスク件数を取得できる
- [ ] 指定した位置のタスクを削除できる
- [x] 初期状態ではタスクは登録されていない
- [ ] タスク内容を指定して同一タスクの有無を判断できる
- [ ] タスクをクリアできるか判断できる
- [x] 追加されたタスクの内容を取得できる
- [x] 追加されたタスクの完了状態を取得できる
- [ ] タスクを追加したらタスク件数の変更通知が行われる
- [ ] タスクの完了状態を変更したらタスク完了件数の変更通知が行われる
- [ ] タスクを削除したらタスク件数の変更通知が行われる
- [ ] タスクを削除したらタスク完了件数の変更通知が行われる
- [ ] タスクをクリアしたらタスク件数の変更通知が行われる
- [ ] タスクをクリアしたらタスク完了件数の変更通知が行われる

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
