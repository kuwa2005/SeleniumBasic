
'
' 検索結果のスクリーンショットを PDF に埋め込む例（Chrome）
'

Class Script
    Dim driver

    Sub Class_Initialize
        Set driver = CreateObject("Selenium.ChromeDriver")
        Set pdf = CreateObject("Selenium.PdfFile")

        pdf.SetPageSize 210, 297, "mm"
        pdf.SetMargins 5, 5, 5, 15, "mm"

        pdf.AddTextCenter "Search for Eiffel tower", 14, true
        pdf.AddSpace 10
        pdf.AddText "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " & _
            "Etiam sit amet libero arcu, et molestie purus. Ut in sem lacus, " & _
            "sit amet rhoncus erat. In aliquet arcu at nunc porta sollicitudin. " & _
            "Cras ante nisl, hendrerit quis bibendum quis, egestas vitae mi."

        driver.Get "https://www.google.co.uk"
        driver.Window.Maximize

        pdf.AddTitle "Search page"
        pdf.AddLink driver.Url
        pdf.AddImage driver.TakeScreenshot()

        driver.Get "/search?q=Eiffel+tower"

        pdf.AddTitle "Results page"
        pdf.AddLink driver.Url
        pdf.AddImage driver.TakeScreenshot()

        pdf.SaveAs "my-capture-chrome.pdf"
    End Sub

    Sub Class_Terminate
        driver.Quit
    End Sub
End Class

Set s = New Script
