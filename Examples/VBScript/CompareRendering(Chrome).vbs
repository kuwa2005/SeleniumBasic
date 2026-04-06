
'
' 2 ページのレンダリングをスクリーンショットで比較（Chrome）
'

Class Script
    Dim driver

    Sub Class_Initialize
        Set driver = CreateObject("Selenium.ChromeDriver")

        driver.Get "https://www.google.co.uk"
        driver.Window.SetSize 1024, 768
        Set imageA = driver.TakeScreenshot(500)
        imageA.SaveAs "image-a.png", False

        driver.Get "https://www.google.fr"
        Set imageB = driver.TakeScreenshot(500)
        imageB.SaveAs "image-b.png", False

        Set imageDiff = imageA.CompareTo(imageB)
        imageDiff.SaveAs "image-diff.png"

        WScript.Echo imageDiff.DiffCount & " different pixels"
    End Sub

    Sub Class_Terminate
        driver.Quit
    End Sub
End Class

Set s = New Script
