
'
' ユーザー データ（プロファイル）を指定して Edge を起動する例
' プロファイル名は %LOCALAPPDATA%\Microsoft\Edge\User Data\ 配下に作成されます。
'

Class Script
    Dim driver

    Sub Class_Initialize
        Set driver = CreateObject("Selenium.EdgeDriver")
        driver.SetProfile "SeleniumBasicExample"
        driver.Get "https://www.microsoft.com"

        WScript.Echo "Click OK to close the browser"
    End Sub

    Sub Class_Terminate
        driver.Quit
    End Sub
End Class

Set s = New Script
