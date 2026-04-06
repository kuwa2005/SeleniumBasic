
'
' VBScript example — Microsoft Edge / Chromium（このフォークの正式対応ブラウザ）
' msedgedriver.exe が PATH または Selenium.dll と同じフォルダにあること。
'

Class Script
    Dim driver

    Sub Class_Initialize
        Set Waiter = CreateObject("Selenium.Waiter")
        Set Assert = CreateObject("Selenium.Assert")
        Set driver = CreateObject("Selenium.EdgeDriver")

        driver.Get "https://www.google.co.uk"
        driver.FindElementByName("q").SendKeys "Eiffel tower" & driver.Keys.Return
        While Waiter.Not(Instr(driver.Title, "Eiffel tower")): Wend
        WScript.Echo "Click OK to quit the browser"
    End Sub

    Sub Class_Terminate
        driver.Quit
    End Sub
End Class

Set s = New Script
