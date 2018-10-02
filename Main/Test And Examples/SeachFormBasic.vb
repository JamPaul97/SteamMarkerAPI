Public Class SeachFormBasic
    Private Sub SeachFormBasic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load all Games from Games Enum to an Array.
        Dim items As Array = System.Enum.GetValues(GetType(SteamMarketAPI.Search.Games))
        'Load all Games from Games Enum to Combobox for selection.
        For Each en In items
            ComboBox1.Items.Add(en)
        Next
        ComboBox1.Sorted = True
    End Sub

    Private Sub SeachFormBasic_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Main.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If ComboBox1.SelectedIndex >= 0 Then
            '[Enum].Parse(GetType(SteamMarketAPI.Search.Games), ComboBox1.SelectedItem)
            'This line will neturn the appid from Games.
            'This work based on selecting the Enum throught its string name.
            'We call the Search function with Start = 0, Count = The velue of the NumericUpDown control on the form, and appid is setted by the Combobox.
            Dim a As New SteamMarketAPI.Search(0, ToolStripTextBox1.Text, [Enum].Parse(GetType(SteamMarketAPI.Search.Games), ComboBox1.SelectedItem))
            'The code below just take the result data and make a new control for each one of it then places it on a tab that gets places on the Tab Control
            'on the form.
            For i As Integer = 0 To a.Results.Count - 1
                Console.WriteLine(a.Results(i).name)
            Next
            For Each item In a.Results
                Console.WriteLine(item.name)
            Next
            'ListView1.Items.Clear()
            'ListView1.Columns.Clear()
            'ListView1.Columns.Add("Name")
            'ListView1.Columns.Add("Hach Name")
            'ListView1.Columns.Add("Sell Listings")
            'ListView1.Columns.Add("Sell Price Text")
            'ListView1.Columns.Add("Sell Price Value")
            'ListView1.Columns.Add("Tradeable")
            'ListView1.Columns.Add("Name Color")
            'ListView1.Columns.Add("Type")
            'ListView1.Columns.Add("Commodity")
            'ListView1.Columns.Add("Market Tradeable Restriction")
            'ListView1.Columns.Add("Market Marketable Restriction")
            'ListView1.Columns.Add("Marketable")
            'For i As Integer = 0 To a.count - 1
            '    ListView1.Items.Add(a.Results(i).name)
            '    ListView1.Items(i).SubItems.Add(a.Results(i).hash_name)
            '    ListView1.Items(i).SubItems.Add(a.Results(i).sell_listings)
            '    ListView1.Items(i).SubItems.Add(a.Results(i).sell_price.Text)
            '    ListView1.Items(i).SubItems.Add(a.Results(i).sell_price.Value)
            '    ListView1.Items(i).SubItems.Add(a.Results(i).tradeable)
            '    ListView1.Items(i).SubItems.Add(a.Results(i).name_color.ToString)
            '    ListView1.Items(i).SubItems.Add(a.Results(i).type)
            '    ListView1.Items(i).SubItems.Add(a.Results(i).commodity)
            '    ListView1.Items(i).SubItems.Add(a.Results(i).market_tradeabe_restriction)
            '    ListView1.Items(i).SubItems.Add(a.Results(i).market_marketable_restriction)
            '    ListView1.Items(i).SubItems.Add(a.Results(i).marketable)
            'Next
        End If
        Dim LVSorter = New ListViewItemDateComparer(1, SortOrder.Ascending)
        ListView1.ListViewItemSorter = LVSorter
    End Sub
End Class

Friend Class ListViewItemDateComparer
    Implements IComparer
    Private col As Integer
    Private _sort As SortOrder = SortOrder.Ascending

    Public Sub New(column As Integer, sort As Windows.Forms.SortOrder)
        col = column
        _sort = sort
    End Sub

    Public Function Compare(x As Object,
                 y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim returnVal As Integer = -1

        ' parse LV contents back to DateTime value
        Dim dtX As String = (CType(x, ListViewItem).SubItems(col).Text)
        Dim dtY As String = (CType(y, ListViewItem).SubItems(col).Text)

        ' compare
        returnVal = String.Compare(dtX, dtY)

        If _sort = SortOrder.Descending Then
            returnVal *= -1
        End If
        Return returnVal

    End Function
End Class