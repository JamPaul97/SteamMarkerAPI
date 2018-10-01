Imports System.Net
Imports System
Imports System.Drawing
Imports Newtonsoft.Json
Public Class Search
    Implements System.IDisposable
    Public Results As New List(Of Result)
    Private _start As Integer = 0
    Private _count As Integer = 1
    Private _appid As Integer = 730
    Public Sub New(ByVal start As Integer, count As Integer, ByVal Game As Games)
        _start = start
        _count = count
        _appid = Game
        Dim tempItem As New JsonStructure
        tempItem = JsonConvert.DeserializeObject(Of JsonStructure)(WebRequest(buildRequestString(True)))
        For Each item In tempItem.results
            Dim temp As New Result
            temp.background_color = ConvertToRbg(item.asset_description.background_color)
            temp.commodity = item.asset_description.commodity
            temp.hash_name = item.asset_description.market_hash_name
            temp.icon_url = item.asset_description.icon_url
            temp.icon_url_large = item.asset_description.icon_url_large
            temp.marketable = item.asset_description.marketable
            temp.market_marketable_restriction = item.asset_description.market_marketable_restriction
            temp.market_tradeabe_restriction = item.asset_description.market_tradedable_restriction
            temp.name = item.asset_description.market_name
            temp.name_color = ConvertToRbg(item.asset_description.name_color)
            temp.sell_listings = item.sell_listings
            temp.sell_price.Value = item.sell_price
            temp.sell_price.Text = item.sell_price_text
            temp.tradeable = item.asset_description.tradeable
            temp.type = item.asset_description.type
            temp.image = getImage(item.asset_description.icon_url)
            temp.image_large = getImage(item.asset_description.icon_url_large)
            Results.Add(temp)
        Next
    End Sub
    Public Sub Dispose()

    End Sub
#Region "Games"
    Public Enum Games
        Team_Fortress_2 = 440
        Dota_2 = 570
        Counter_Strike_Global_Offensive = 730
        Steam = 753
        Natural_Selection_2 = 4920
        SpeedRunners = 207140
        PAYDAY_2 = 218620
        Blade_Symphony = 225600
        Euro_Truck_Simulator_2 = 227300
        Warframe = 230410
        Killing_Floor_2 = 232090
        BattleBlock_Theater = 238460
        Path_of_Exile = 238960
        Space_Engineers = 244850
        SNOW = 244930
        SteamVR = 250820
        Rust = 252490
        Zombie_Grinder = 263920
        Subnautica = 264710
        Robot_Roller_Derby_Disco_Dodgeball = 270450
        American_Truck_Simulator = 270880
        Depth = 274940
        Armello = 290340
        Just_Survive = 295110
        Ballistic_Overkill = 296300
        Miscreated = 299740
        Call_to_Arms = 302670
        Unturned = 304930
        Altitude0_Lower_Faster = 308080
        Primal_Carnage_Extinction = 321360
        Supraball = 321400
        Dont_Starve_Together = 322330
        Move_or_Die = 323850
        Reflex_Arena = 328070
        Ratz_Instagib_2 = 338170
        Deadhold = 346930
        Immune = 348670
        Interstellar_Rift = 363360
        FreeCell_Quest = 364640
        Savage_Resurrection = 366440
        Gremlins_Inc = 369990
        Hired_Ops = 374280
        Ember_Strike = 374670
        Stardrift_Nomads = 381250
        Forgotten_Lore = 391240
        Business_Tour_Online_Multiplayer_Board_Game = 397900
        Dinosaur_Hunt = 401190
        BATTLECREW_Space_Pirates = 411480
        Emily_is_Away = 417860
        Mech_Anarchy = 420900
        Bunny_Hop_League = 429780
        Golf_With_Your_Friends = 431240
        Wallpaper_Engine = 431960
        Heliborne = 433530
        H1Z1 = 433850
        The_Culling = 437220
        Survival_Zombies_The_Inverted_Evolution = 440730
        Day_of_Infamy = 447820
        Holopoint = 457960
        Screeps = 464350
        Nine_Parchments = 471550
        Ball_3D_Soccer_Online = 485610
        Fruit_Ninja_VR = 486780
        BATTALION_1944 = 489940
        Shoot_Mania_VR_Fun_Zombies = 496960
        Dinosaur_Forest = 506730
        Project_Lounge = 508710
        Intralism = 513510
        MineSweeper_VR = 516940
        Redout_Enhanced_Edition = 517710
        INTERSHELTER = 520530
        SosSurvival = 528970
        Brawl_of_Ages = 529840
        Slymes = 530300
        Argo = 530700
        Bloody_Walls = 531960
        MegaRats = 534210
        Children_of_Orc = 544840
        Machine_Hunt = 546930
        Black_Squad = 550650
        Alien_Hostage = 562430
        Golf_It! = 571740
        Blood_Feed = 575950
        PLAYERUNKNOWNS_BATTLEGROUNDS = 578080
        HUNGER = 581740
        Awesome_Metal_Detecting = 582810
        Arcane_Raise = 603750
        monstercakes = 614910
        Burst_The_Game = 615050
        OLDTV = 643270
        Be_Quiet! = 650580
        Unearthing_Process = 654700
        VODKA = 655010
        Rival_Rampage = 663690
        Died_Of_Fear = 663920
        DeDrive = 672490
        Undarkened = 676340
        HalfLife_CAGED = 679990
        Shoppe_Keep_2 = 684580
        BLOCKPOST = 706990
        Rebons = 708940
        nbody_VR = 714910
        Islands_of_Nyne_Battle_Royale = 728540
        Epic_Royal = 744760
        DEAD_DOZEN = 749780
        Villages = 749820
        Moon_Bullet = 749830
        ULTIMATE_ARENA_SHOWDOWN = 757160
        Realm_Revolutions = 764030
        SUMETRICK = 771950
        Lifeblood = 796340
        Oleas_Messenger = 798640
        PAS = 805110
        Burst_Into = 829080
        Darts_and_Friends = 832680
        Have_A_Sticker = 841860
        Rogue_Agent = 843660
        Black_Faith = 845870
        Elon_Musk_Simulator = 852740
        USA_2020 = 859700
        Anyway = 866510
        Golf_Galore = 868080
        Dinosaur_Hunt_Puzzle = 874400
        Sophisticated_Puzzles = 875670
        Ecchi_Cards = 890180
        Ecchi_Puzzle = 890710
        Do_or_Die = 907720
        Land_of_Puzzles_Knights = 922130
        The_Ultimate_Clicker_Master_of_the_Universe = 924890
        Professor_Watts_Memory_Match_Cats = 936800
        Fitzzle_Cute_Kittens = 937640


    End Enum
#End Region
    Public Property start As Integer
        Get
            Return _start
        End Get
        Set(value As Integer)
            If value < 0 Then
                Throw New ArgumentException("Value must be greater than or equal to zero.", "Search.Start")
            Else
                _start = value
            End If
        End Set
    End Property
    Public Property count As Integer
        Get
            Return _count
        End Get
        Set(value As Integer)
            If value <= 0 Then
                Throw New ArgumentException("Value must be greater than or equal to one.", "Search.Count")
            Else
                _count = value
            End If
        End Set
    End Property
    Public Property appid As Integer
        Get
            Return _appid
        End Get
        Set(value As Integer)
            _appid = value
        End Set
    End Property
    ''' <summary>
    ''' Returns the builed URL for the GET command.
    ''' </summary>
    ''' <param name="appid">The game's Steam appid.</param>
    ''' <returns>URL as string.</returns>
    Private Function buildRequestString(ByVal appid As Games) As String
        Return (String.Format("https://steamcommunity.com/market/search/render/?query=&start={0}&count={1}&appid={2}&norender=1", _start, _count, appid))
    End Function
    ''' <summary>
    ''' Returns the builed URL for the GET command.
    ''' </summary>
    ''' <param name="Overload">if true then appid must be setted manually.</param>
    ''' <returns>URL as string.</returns>
    Private Function buildRequestString(ByVal Overload As Boolean) As String
        Return (String.Format("https://steamcommunity.com/market/search/render/?query=&start={0}&count={1}&appid={2}&norender=1", _start, _count, _appid))
    End Function
    Private Function WebRequest(ByVal str As String) As String
        Dim webClient As New WebClient
        Dim result As String = webClient.DownloadString(str)
        Return (result)
    End Function
    Private Function getImage(ByVal str As String) As Image
        Try
            Dim tClient As WebClient = New WebClient
            Dim a = tClient.DownloadData("https://steamcommunity.com/economy/image/" & str)
            Dim tImage As Bitmap = Bitmap.FromStream(New IO.MemoryStream(a))
            Return (tImage)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function
    Public Function ConvertToRbg(ByVal HexColor As String) As Color
        Dim Red As String
        Dim Green As String
        Dim Blue As String
        HexColor = Replace(HexColor, "#", "")
        Red = Val("&H" & Mid(HexColor, 1, 2))
        Green = Val("&H" & Mid(HexColor, 3, 2))
        Blue = Val("&H" & Mid(HexColor, 5, 2))
        Return Color.FromArgb(Red, Green, Blue)
    End Function

    Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
        Throw New NotImplementedException()
    End Sub

    Private Class JsonStructure
        Public Property success As Boolean
        Public Property start As Integer
        Public Property pagesize As Integer
        Public Property total_count As Integer
        Public Property searchdata As New _searchdataclass
        Public Property results As New List(Of result)

        Public Class _searchdataclass
            Public Property query As String
            Public Property search_description As Boolean
            Public Property total_count As Integer
            Public Property pagesize As Integer
            Public Property class_prefix As String
        End Class
        Public Class result
            Public Property name As String
            Public Property hash_name As String
            Public Property sell_listings As Integer
            Public Property sell_price As Integer
            Public Property sell_price_text As String
            Public Property app_icon As String
            Public Property app_name As String
            Public Property asset_description As New asset
            Public Property sale_price_text As String
            Public Class asset
                Public Property appid As Integer
                Public Property classid As String
                Public Property instanceid As String
                Public Property currency As Integer
                Public Property background_color As String
                Public Property icon_url As String
                Public Property icon_url_large As String
                Public Property descriptions As New List(Of description)
                Public Property tradeable As Integer
                Public Property name As String
                Public Property name_color As String
                Public Property type As String
                Public Property market_name As String
                Public Property market_hash_name As String
                Public Property commodity As Integer
                Public Property market_tradedable_restriction As Integer
                Public Property market_marketable_restriction As Integer
                Public Property marketable As Integer
                Public Class description
                    Public Property type As String
                    Public Property value As String
                End Class
            End Class
        End Class
    End Class

    Public Class Result
        Public Property name As String
        Public Property hash_name As String
        Public Property sell_listings As Integer
        Public Property sell_price As New sell
        Public Property background_color As Color
        Public Property icon_url As String
        Public Property image As Image
        Public Property image_large As Image
        Public Property icon_url_large As String
        Public Property tradeable As Integer
        Public Property name_color As Color
        Public Property type As String
        Public Property commodity As Integer
        Public Property market_tradeabe_restriction As Integer
        Public Property market_marketable_restriction As Integer
        Public Property marketable As Integer
        Public Class sell
            Public Property Text As String
            Public Property Value As Integer
        End Class
    End Class

End Class
