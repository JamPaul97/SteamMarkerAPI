Imports SteamMarketAPI
Public Class SearchForm
    Private Sub SearchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load all Games from Games Enum to an Array.
        Dim items As Array = System.Enum.GetValues(GetType(SteamMarketAPI.Search.Games))
        'Load all Games from Games Enum to Combobox for selection.
        For Each en In items
            ComboBox1.Items.Add(en)
        Next
        ComboBox1.Sorted = True
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex >= 0 Then
            '[Enum].Parse(GetType(SteamMarketAPI.Search.Games), ComboBox1.SelectedItem)
            'This line will neturn the appid from Games.
            'This work based on selecting the Enum throught its string name.
            'We call the Search function with Start = 0, Count = The velue of the NumericUpDown control on the form, and appid is setted by the Combobox.
            Dim a As New SteamMarketAPI.Search(0, NumericUpDown1.Value, [Enum].Parse(GetType(SteamMarketAPI.Search.Games), ComboBox1.SelectedItem))
            'The code below just take the result data and make a new control for each one of it then places it on a tab that gets places on the Tab Control
            'on the form.
            TabControl1.TabPages.Clear()

            For Each item In a.Results
                Dim newTab As New TabPage
                newTab.Text = item.name
                Dim newControl As New MarketSearchItem
                newControl.Label1.Text = "Name : " & item.name
                newControl.Label2.Text = "Hash Name : " & item.hash_name
                newControl.Label3.Text = "Sell Listings : " & item.sell_listings
                newControl.Label4.Text = "Sell Price Text : " & item.sell_price.Text
                newControl.Label5.Text = "Sell Price Value : " & item.sell_price.Value
                newControl.PictureBox1.Image = item.image
                newControl.Label7.Text = "Tradeable : " & item.tradeable
                newControl.Label8.Text = "Name Color "
                newControl.Label8.ForeColor = item.name_color
                newControl.Label9.Text = "Type : " & item.type
                newControl.Label10.Text = "Commodity : " & item.commodity
                newControl.Label11.Text = "Market Tradeable Restriction : " & item.market_marketable_restriction
                newControl.Label12.Text = "Market Marketable Restriction : " & item.market_tradeabe_restriction
                newControl.Label13.Text = "Marketable : "
                newControl.BackColor = item.background_color
                newTab.Controls.Add(newControl)
                newTab.BackColor = item.background_color
                TabControl1.TabPages.Add(newTab)
            Next
        End If
    End Sub

    Private Sub SearchForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Main.Show()
    End Sub
End Class