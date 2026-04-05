# SeleniumBasic（フォーク）

[florentbr/SeleniumBasic](https://github.com/florentbr/SeleniumBasic) をベースにしたフォークです。**正式にサポートするブラウザは次の 2 つのみです: Google Chrome（chromedriver）と Microsoft Edge / Chromium（msedgedriver）**。`Selenium.ChromeDriver`・`Selenium.EdgeDriver`、または `WebDriver.Start "chrome"` / `"edge"` で利用します。**Firefox / Internet Explorer / Opera / PhantomJS 等は COM 互換のため ProgId・型を残していますが、`Start` / `StartRemotely` では使用できません**（`ChromeOnlyBrowserError）。

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

## オプション・トラブルシューティング

- **chromedriver / msedgedriver 起動時に Access denied（Job オブジェクト）**  
  環境変数 **`SELENIUM_BASIC_DRIVER_NO_JOB=1`**（または `true` / `yes`）を設定すると、ドライバプロセスに Job を付けずに起動します（upstream #283 / #291 系の回避策）。

- **自動化バナー・`navigator.webdriver` 検出の緩和（完全ではない）**  
  セッション開始前に **`SetExcludeEnableAutomationSwitch True`** を呼ぶと、`excludeSwitches` に `enable-automation` と `useAutomationExtension: false` を付与します（Chrome / Edge）。さらに抑えたい場合は **`AddArgument "--disable-blink-features=AutomationControlled"`** などを併用してください（upstream #216）。

- **要素が非表示になるまで待つ（Selenium の invisibilityOfElementLocated 相当）**  
  **`WaitInvisibilityOfElementLocated`** を使用します（DOM から消えるまでしか待たない **`WaitNotElement`** とは別）。`By.Any` は未対応です。

## ライセンス

- 英語: [`LICENSE.txt`](LICENSE.txt)
- 日本語参考訳: [`LICENSE.ja.txt`](LICENSE.ja.txt)（法的効力は英語版に従います）
