# 元リポジトリ Issue 取り込みバックログ（フォーク作業用）

[florentbr/SeleniumBasic](https://github.com/florentbr/SeleniumBasic) の Open Issue から、**このフォークで追う価値が高いもの**を選び、**実装順（おまかせ版）**を固定したメモ。  
方針は `MAINTENANCE_MEMO.md`（特に**下位互換最優先**）に従う。

**スコープ**: ブラウザは **Chrome のみ**（フェーズ C の Edge 系 Issue は参考用・優先度低）。

## 凡例

- **難易度**: L = 比較的局所 / M = 複数モジュール・要検証 / H = 仕様・ブラウザ・ドライバ横断
- **状態**: 未着手 / 調査中 / PR 予定 / 保留（理由メモ）

## 推奨フェーズ（全体の進め方）

1. **フェーズ A — 土台**: ドライバ探索・パス・ファイル名（多くの「動かない」の前提を直す）
2. **フェーズ B — プロセス周り**: 起動・権限・ジョブオブジェクト（再現できれば効果大）
3. **フェーズ C — Chrome/Edge 実用**: アタッチ、ウィンドウ/タブ、起動直後の挙動
4. **フェーズ D — モダン DOM**: Shadow DOM 等（**既定挙動は変えず**、追加 API / オプションで寄せる）
5. **フェーズ E — 待機・細部**: ExecuteScript 待ち、SendKeys、frame 等

---

## フェーズ A（最優先）

| 順 | Upstream | 題名（要約） | 難易度 | 状態 | メモ |
|----|----------|----------------|--------|------|------|
| A1 | [#274](https://github.com/florentbr/SeleniumBasic/issues/274) | 新しい ChromeDriver で `chromedriver.exe` が見つからない | M | **対応済** | 複数候補パス・環境変数・PATH。`README.md` 参照 |
| A2 | [#287](https://github.com/florentbr/SeleniumBasic/issues/287) | VBA から ChromeDriver パスを変える構文 | L | **対応済** | `SetChromeDriverPath` / `chrome.serverBinary`（`README.md`） |

## フェーズ B

| 順 | Upstream | 題名（要約） | 難易度 | 状態 | メモ |
|----|----------|----------------|--------|------|------|
| B1 | [#283](https://github.com/florentbr/SeleniumBasic/issues/283) | `ProcessExt.cs` 付近 Win32Exception / Access denied | M | 未着手 | 行番号あり。**挙動分岐は明示フラグ**検討 |
| B2 | [#291](https://github.com/florentbr/SeleniumBasic/issues/291) | Access is denied（関連） | M | 未着手 | B1 と統合調査可 |

## フェーズ C

| 順 | Upstream | 題名（要約） | 難易度 | 状態 | メモ |
|----|----------|----------------|--------|------|------|
| C1 | [#267](https://github.com/florentbr/SeleniumBasic/issues/267) | 既存 Chrome インスタンスにアタッチできない（114 以降） | H | 未着手 | 引数・ポート・セキュリティ設定の変化 |
| C2 | [#268](https://github.com/florentbr/SeleniumBasic/issues/268) | ウィンドウ切替（タイトル） | M | 未着手 | [#203](https://github.com/florentbr/SeleniumBasic/issues/203) タブ切替と関連 |
| C3 | [#276](https://github.com/florentbr/SeleniumBasic/issues/276) | Edge 119 で壊れた疑い | M | 未着手 | |
| C4 | [#282](https://github.com/florentbr/SeleniumBasic/issues/282) | `.Start "edge"` で空白ページ | M | 未着手 | C3 とまとめて Edge 起動経路を見る |
| C5 | [#248](https://github.com/florentbr/SeleniumBasic/issues/248) | Edge が開かない（ドライバ追加後も） | M | 未着手 | |
| C6 | [#241](https://github.com/florentbr/SeleniumBasic/issues/241) | Edge ヘッドレスが動かない | M | 未着手 | |

## フェーズ D（互換に注意）

| 順 | Upstream | 題名（要約） | 難易度 | 状態 | メモ |
|----|----------|----------------|--------|------|------|
| D1 | [#280](https://github.com/florentbr/SeleniumBasic/issues/280) | `shadowRoot` が Dictionary（WebElement にしたい） | M | 未着手 | **返却型の既定変更は避け**、別 API / フラグで |
| D2 | [#198](https://github.com/florentbr/SeleniumBasic/issues/198) | Shadow-root 内の要素 | M | 未着手 | D1 と一体設計 |

## フェーズ E

| 順 | Upstream | 題名（要約） | 難易度 | 状態 | メモ |
|----|----------|----------------|--------|------|------|
| E1 | [#273](https://github.com/florentbr/SeleniumBasic/issues/273) | Chrome 117: click 後 drag でリンク破損 | M | 未着手 | 再現が鍵 |
| E2 | [#252](https://github.com/florentbr/SeleniumBasic/issues/252) | loading status 判定エラー（最新 ChromeDriver） | H | 未着手 | [#240](https://github.com/florentbr/SeleniumBasic/issues/240) と関連しうる |
| E3 | [#270](https://github.com/florentbr/SeleniumBasic/issues/270) / [#189](https://github.com/florentbr/SeleniumBasic/issues/189) | frame 内要素 | M | 未着手 | |
| E4 | [#259](https://github.com/florentbr/SeleniumBasic/issues/259) | ExecuteScript の非同期完了待ち | M | 未着手 | **既定タイムアウトは据え置き**、明示指定で |
| E5 | [#244](https://github.com/florentbr/SeleniumBasic/issues/244) | 追加 HTTP ヘッダ | M | 未着手 | capabilities 経路 |
| E6 | [#216](https://github.com/florentbr/SeleniumBasic/issues/216) | `navigator.webdriver` 無効化 | L | 未着手 | オプション文書化＋渡し方 |
| E7 | [#266](https://github.com/florentbr/SeleniumBasic/issues/266) | プロファイルと `scope_dir` | M | 未着手 | |
| E8 | [#181](https://github.com/florentbr/SeleniumBasic/issues/181) | `invisibilityOfElementLocated` 等 | M | 未着手 | 待機 API 追加寄り |

## 意図的に後回し（このバックログから外す／別メモ）

- 別プロジェクト移行、Captcha、コード署名、特定サイトのスクレイピング手順、誤検知トロイの話などは **本バックログのスコープ外**（必要なら別ファイル）。

## 作業時のメモ欄（自由記述）

- （調査メモ・再現環境・ブランチ名など）

---
*選定・順序は「おまかせ」版。進めながら差し替えてよい。*
