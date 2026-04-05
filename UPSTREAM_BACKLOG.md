# 元リポジトリ Issue 取り込みバックログ（フォーク作業用）

[florentbr/SeleniumBasic](https://github.com/florentbr/SeleniumBasic) の Open Issue から、**このフォークで追う価値が高いもの**を選び、**実装順（おまかせ版）**を固定したメモ。  
方針は `MAINTENANCE_MEMO.md`（特に**下位互換最優先**）に従う。

**スコープ**: **主に Chrome**。Edge（Chromium）はフォークで **msedgedriver 経路を復活**済み。フェーズ C の Edge 系 upstream Issue は**参考用・優先度低**（必要ならフォーク Issue で個別に追う）。

**フォーク Issue**: 下表の「フォーク Issue」列は [kuwa2005/SeleniumBasic](https://github.com/kuwa2005/SeleniumBasic) 上の追跡用 Issue（`UPSTREAM_BACKLOG.md` 由来）へのリンクです。

## 凡例

- **難易度**: L = 比較的局所 / M = 複数モジュール・要検証 / H = 仕様・ブラウザ・ドライバ横断
- **状態**: 未着手 / 調査中 / PR 予定 / 保留（理由メモ）

## 推奨フェーズ（全体の進め方）

1. **フェーズ A — 土台**: ドライバ探索・パス・ファイル名（多くの「動かない」の前提を直す）
2. **フェーズ B — プロセス周り**: 起動・権限・ジョブオブジェクト（再現できれば効果大）
3. **フェーズ C — Chrome/Edge 実用**: ウィンドウ/タブ、起動直後の挙動（**[#267](https://github.com/florentbr/SeleniumBasic/issues/267) 既存 Chrome へのアタッチはこのフォークでは対応しない**）
4. **フェーズ D — モダン DOM**: Shadow DOM 等（**既定挙動は変えず**、追加 API / オプションで寄せる）
5. **フェーズ E — 待機・細部**: ExecuteScript 待ち、SendKeys、frame 等

---

## フェーズ A（最優先）

| 順 | Upstream | 題名（要約） | 難易度 | 状態 | フォーク Issue | メモ |
|----|----------|----------------|--------|------|----------------|------|
| A1 | [#274](https://github.com/florentbr/SeleniumBasic/issues/274) | 新しい ChromeDriver で `chromedriver.exe` が見つからない | M | **対応済** | [#9](https://github.com/kuwa2005/SeleniumBasic/issues/9) | 複数候補パス・環境変数・PATH。`README.md` 参照 |
| A2 | [#287](https://github.com/florentbr/SeleniumBasic/issues/287) | VBA から ChromeDriver パスを変える構文 | L | **対応済** | [#10](https://github.com/kuwa2005/SeleniumBasic/issues/10) | `SetChromeDriverPath` / `chrome.serverBinary`（`README.md`） |

## フェーズ B

| 順 | Upstream | 題名（要約） | 難易度 | 状態 | フォーク Issue | メモ |
|----|----------|----------------|--------|------|----------------|------|
| B1 | [#283](https://github.com/florentbr/SeleniumBasic/issues/283) | `ProcessExt.cs` 付近 Win32Exception / Access denied | M | 未着手 | [#11](https://github.com/kuwa2005/SeleniumBasic/issues/11) | 行番号あり。**挙動分岐は明示フラグ**検討 |
| B2 | [#291](https://github.com/florentbr/SeleniumBasic/issues/291) | Access is denied（関連） | M | 未着手 | [#12](https://github.com/kuwa2005/SeleniumBasic/issues/12) | B1 と統合調査可 |

## フェーズ C

| 順 | Upstream | 題名（要約） | 難易度 | 状態 | フォーク Issue | メモ |
|----|----------|----------------|--------|------|----------------|------|
| C1 | [#267](https://github.com/florentbr/SeleniumBasic/issues/267) | 既存 Chrome インスタンスにアタッチできない（114 以降） | H | **実施しない** | [#8](https://github.com/kuwa2005/SeleniumBasic/issues/8) | このフォークのスコープ外（メンテ負荷・仕様変化に追わない方針） |
| C2 | [#268](https://github.com/florentbr/SeleniumBasic/issues/268) | ウィンドウ切替（タイトル） | M | 未着手 | [#13](https://github.com/kuwa2005/SeleniumBasic/issues/13) | [#203](https://github.com/florentbr/SeleniumBasic/issues/203) タブ切替と関連 |
| C3 | [#276](https://github.com/florentbr/SeleniumBasic/issues/276) | Edge 119 で壊れた疑い | M | 未着手 | [#14](https://github.com/kuwa2005/SeleniumBasic/issues/14) | |
| C4 | [#282](https://github.com/florentbr/SeleniumBasic/issues/282) | `.Start "edge"` で空白ページ | M | 未着手 | [#15](https://github.com/kuwa2005/SeleniumBasic/issues/15) | C3 とまとめて Edge 起動経路を見る |
| C5 | [#248](https://github.com/florentbr/SeleniumBasic/issues/248) | Edge が開かない（ドライバ追加後も） | M | 未着手 | [#16](https://github.com/kuwa2005/SeleniumBasic/issues/16) | |
| C6 | [#241](https://github.com/florentbr/SeleniumBasic/issues/241) | Edge ヘッドレスが動かない | M | 未着手 | [#17](https://github.com/kuwa2005/SeleniumBasic/issues/17) | |

## フェーズ D（互換に注意）

| 順 | Upstream | 題名（要約） | 難易度 | 状態 | フォーク Issue | メモ |
|----|----------|----------------|--------|------|----------------|------|
| D1 | [#280](https://github.com/florentbr/SeleniumBasic/issues/280) | `shadowRoot` が Dictionary（WebElement にしたい） | M | 未着手 | [#18](https://github.com/kuwa2005/SeleniumBasic/issues/18) | **返却型の既定変更は避け**、別 API / フラグで |
| D2 | [#198](https://github.com/florentbr/SeleniumBasic/issues/198) | Shadow-root 内の要素 | M | 未着手 | [#19](https://github.com/kuwa2005/SeleniumBasic/issues/19) | D1 と一体設計 |

## フェーズ E

| 順 | Upstream | 題名（要約） | 難易度 | 状態 | フォーク Issue | メモ |
|----|----------|----------------|--------|------|----------------|------|
| E1 | [#273](https://github.com/florentbr/SeleniumBasic/issues/273) | Chrome 117: click 後 drag でリンク破損 | M | 未着手 | [#20](https://github.com/kuwa2005/SeleniumBasic/issues/20) | 再現が鍵 |
| E2 | [#252](https://github.com/florentbr/SeleniumBasic/issues/252) | loading status 判定エラー（最新 ChromeDriver） | H | 未着手 | [#21](https://github.com/kuwa2005/SeleniumBasic/issues/21) | [#240](https://github.com/florentbr/SeleniumBasic/issues/240) と関連しうる |
| E3 | [#270](https://github.com/florentbr/SeleniumBasic/issues/270) / [#189](https://github.com/florentbr/SeleniumBasic/issues/189) | frame 内要素 | M | 未着手 | [#22](https://github.com/kuwa2005/SeleniumBasic/issues/22) | |
| E4 | [#259](https://github.com/florentbr/SeleniumBasic/issues/259) | ExecuteScript の非同期完了待ち | M | 未着手 | [#23](https://github.com/kuwa2005/SeleniumBasic/issues/23) | **既定タイムアウトは据え置き**、明示指定で |
| E5 | [#244](https://github.com/florentbr/SeleniumBasic/issues/244) | 追加 HTTP ヘッダ | M | 未着手 | [#24](https://github.com/kuwa2005/SeleniumBasic/issues/24) | capabilities 経路 |
| E6 | [#216](https://github.com/florentbr/SeleniumBasic/issues/216) | `navigator.webdriver` 無効化 | L | 未着手 | [#25](https://github.com/kuwa2005/SeleniumBasic/issues/25) | オプション文書化＋渡し方 |
| E7 | [#266](https://github.com/florentbr/SeleniumBasic/issues/266) | プロファイルと `scope_dir` | M | 未着手 | [#26](https://github.com/kuwa2005/SeleniumBasic/issues/26) | |
| E8 | [#181](https://github.com/florentbr/SeleniumBasic/issues/181) | `invisibilityOfElementLocated` 等 | M | 未着手 | [#27](https://github.com/kuwa2005/SeleniumBasic/issues/27) | 待機 API 追加寄り |

## 意図的に後回し（このバックログから外す／別メモ）

- **[#267](https://github.com/florentbr/SeleniumBasic/issues/267)（既存 Chrome へのアタッチ）**は **実装しない**（上表 C1・フォーク [#8](https://github.com/kuwa2005/SeleniumBasic/issues/8) 参照）。
- 別プロジェクト移行、Captcha、コード署名、特定サイトのスクレイピング手順、誤検知トロイの話などは **本バックログのスコープ外**（フォーク追跡: [#28](https://github.com/kuwa2005/SeleniumBasic/issues/28)）。

## 作業時のメモ欄（自由記述）

- （調査メモ・再現環境・ブランチ名など）

---
*選定・順序は「おまかせ」版。進めながら差し替えてよい。*
