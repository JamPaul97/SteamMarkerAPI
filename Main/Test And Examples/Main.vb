Imports System.Text
Imports SteamMarketAPI
Public Class Main
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        SearchForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SeachFormBasic.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim item As New Item(Item.Games.Rust, Item.CurrencySymbol.Euro, "Weapon%20Barrel")
        MsgBox(item.Result.lowest_price)
    End Sub
End Class
