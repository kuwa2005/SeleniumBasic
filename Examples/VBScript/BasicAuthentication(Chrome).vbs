
'
' URL にユーザー名・パスワードを含める Basic 認証の例（Chrome）
' （旧サンプルの Firefox 専用 NTLM 説明は、Chrome では URL 形式の Basic に置き換え）
'

Class Script
    Dim driver

    Sub Class_Initialize
        Set driver = CreateObject("Selenium.ChromeDriver")
        driver.Get "http://test:test@browserspy.dk/password-ok.php"

        WScript.Echo "Click OK to quit the browser"
    End Sub

    Sub Class_Terminate
        driver.Quit
    End Sub
End Class

Set s = New Script
