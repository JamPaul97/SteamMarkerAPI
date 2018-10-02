Imports System.Net
Imports Newtonsoft.Json
Public Class Item
    Public Result As _Result
    'https://steamcommunity.com/market/priceoverview/?appid=730&currency=3&market_hash_name=Horizon%20Case%20Key
    Public Enum CurrencySymbol
        American_Dollar = 1
        British_Pound = 2
        Euro = 3
        Switch_Franc = 4
    End Enum
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
    Private _appid As Integer
    Private _currency As CurrencySymbol
    Private _market_hash_name As String
    Public Property appid As Integer
        Get
            Return _appid
        End Get
        Set(value As Integer)
            _appid = value
        End Set
    End Property
    Public Property currency As CurrencySymbol
        Get
            Return _currency
        End Get
        Set(value As CurrencySymbol)
            _currency = value
        End Set
    End Property
    Public Property market_hash_name As String
        Get
            Return _market_hash_name
        End Get
        Set(value As String)
            _market_hash_name = value
        End Set
    End Property
    Private Function buildRequestString(ByVal appid As Integer) As String
        Dim b As Integer = _currency
        Dim a = (String.Format("https://steamcommunity.com/market/priceoverview/?appid={0}&currency={1}&market_hash_name={2}", _appid, Int(_currency), market_hash_name))
        Return (String.Format("https://steamcommunity.com/market/priceoverview/?appid={0}&currency={1}&market_hash_name={2}", _appid, Int(_currency), market_hash_name))
    End Function
    Private Function WebRequest(ByVal str As String) As String
        Dim webClient As New WebClient
        Dim result As String = webClient.DownloadString(str)
        Return (result)
    End Function
    Public Sub New(ByVal pAppid As Games, ByVal pCurreny As CurrencySymbol, ByVal pMarket_Hach_Name As String)
        _appid = pAppid
        _currency = pCurreny
        _market_hash_name = pMarket_Hach_Name
        Dim tempItem As New JsonStructure
        tempItem = JsonConvert.DeserializeObject(Of JsonStructure)(WebRequest(buildRequestString(pAppid)))
        Dim tempClass As New _Result
        tempClass.lowest_price = tempItem.lowest_price
        tempClass.median_price = tempItem.median_price
        tempClass.volume = tempItem.volume
        Result = tempClass
    End Sub
    Public Class JsonStructure
        Public Property success As Boolean
        Public Property lowest_price As String
        Public Property volume As String
        Public Property median_price As String
    End Class
    Public Class _Result
        Public Property lowest_price As String
        Public Property volume As String
        Public Property median_price As String
    End Class
    '{"success":true,"lowest_price":"176,89 p\u0443\u0431.","volume":"2,663","median_price":"176,95 p\u0443\u0431."}
End Class
