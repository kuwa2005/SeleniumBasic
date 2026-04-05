# SeleniumBasic（フォーク）

[florentbr/SeleniumBasic](https://github.com/florentbr/SeleniumBasic) をベースにしたフォークです。**メンテナンスの主対象は Google Chrome（chromedriver）**です。**Microsoft Edge（Chromium / msedgedriver）**も `Selenium.EdgeDriver` および `Start "edge"` で利用できます。その他のブラウザは従来どおり COM スタブ寄りです。

## ドキュメント

- 開発方針・互換性: [`MAINTENANCE_MEMO.md`](MAINTENANCE_MEMO.md)
- upstream Issue バックログ: [`UPSTREAM_BACKLOG.md`](UPSTREAM_BACKLOG.md)

## ビルド

- Visual Studio または MSBuild で `SeleniumBasic.sln` を開き、**Release**（推奨）または Debug でビルド
- ターゲット: **.NET Framework 4.8**
- `chromedriver.exe` は `References\chromedriver.exe` に置くと出力フォルダへコピーされます（存在する場合のみ）
- Edge 用の **`msedgedriver.exe`** を `References\msedgedriver.exe` に置くと、ビルド後に出力フォルダへコピーされます（存在する場合のみ）

## chromedriver の場所（優先順）

1. セッション開始前に **`SetChromeDriverPath`（COM）** または **`SetCapability "chrome.serverBinary", "フルパス"`**（ローカル起動時。送信前に除去されます）
2. 環境変数 **`CHROMEDRIVER_PATH`** または **`webdriver.chrome.driver`** または **`CHROMEDRIVER`**
3. `Selenium.dll` と同じフォルダの  
   `chromedriver.exe` / `chromedriver-win64\chromedriver.exe` / `chromedriver-win32\chromedriver.exe` / `chromedriver\chromedriver.exe`
4. **`PATH`** 上の `chromedriver.exe`

## msedgedriver（Edge）の場所（優先順）

1. **`SetEdgeDriverPath`（COM）** または **`SetCapability "edge.serverBinary", "フルパス"`**（ローカル起動時。リモート送信前に除去）
2. 環境変数 **`EDGEWEBDRIVER_PATH`** または **`webdriver.edge.driver`** または **`EDGEDRIVER`** / **`MSEDGEDRIVER`**
3. `Selenium.dll` と同じフォルダの `msedgedriver.exe` / `edgedriver.exe` / `edgedriver-win64\` 配下
4. **`PATH`** 上の `msedgedriver.exe` または `edgedriver.exe`

## ライセンス

- 英語: [`LICENSE.txt`](LICENSE.txt)
- 日本語参考訳: [`LICENSE.ja.txt`](LICENSE.ja.txt)（法的効力は英語版に従います）
