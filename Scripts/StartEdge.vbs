
'
' Quick open Microsoft Edge via Selenium.EdgeDriver (msedgedriver が PATH または Selenium フォルダに必要)
'

Class Script
	Dim driver
    
	Sub Class_Initialize
        Set driver = CreateObject("Selenium.EdgeDriver")
        driver.Get "https://www.google.com"
        WScript.Echo "Title=" & driver.Title & vbLF & "Click OK to terminate"
	End Sub
	
	Sub Class_Terminate
		driver.Quit
	End Sub
End Class

Set s = New Script

