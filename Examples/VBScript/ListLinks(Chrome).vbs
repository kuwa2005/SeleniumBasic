
'
' VBScript example — ページ内リンク一覧（Chrome）
'

Class Script
    Dim driver

    Sub Class_Initialize
        Set driver = CreateObject("Selenium.ChromeDriver")
        driver.Get "https://www.google.co.uk"
        Set links = driver.FindElementsByTag("a").Attribute("href")
        WScript.Echo links.Count & " Links:" & vbCr & Join(links.Values, vbCr)
    End Sub

    Sub Class_Terminate
        driver.Quit
    End Sub
End Class

Set s = New Script
