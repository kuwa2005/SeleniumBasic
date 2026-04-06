
'
' VBScript example — リンク一覧を Excel に出力（Chrome）
'

Class Script
    Dim driver

    Sub Class_Initialize
        Set driver = CreateObject("Selenium.ChromeDriver")
        driver.Get "https://en.wikipedia.org/wiki/Main_Page"

        Set links = driver.FindElementsByCss("a").Attribute("href")
        links.Distinct
        links.Sort

        Set excel = CreateObject("Excel.Application")
        excel.WorkBooks.Add
        excel.Visible = 1

        links.ToExcel excel.ActiveSheet, "Links"
    End Sub

    Sub Class_Terminate
        driver.Quit
    End Sub
End Class

Set s = New Script
