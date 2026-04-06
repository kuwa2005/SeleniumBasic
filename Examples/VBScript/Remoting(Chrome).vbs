
'
' リモートの Selenium Grid / スタンドアロンサーバーに接続する例（Chrome）
' サーバー起動例: java -jar selenium-server-4.x.x.jar standalone
' 既定の URL は環境に合わせて変更してください。
'

Const URI_SERVER = "http://127.0.0.1:4444/wd/hub"

Class Script
    Dim driver

    Sub Class_Initialize
        Set driver = CreateObject("Selenium.WebDriver")
        driver.StartRemotely URI_SERVER, "chrome"
        driver.Wait 1000
    End Sub

    Sub Class_Terminate
        driver.Quit
    End Sub
End Class

Set s = New Script
