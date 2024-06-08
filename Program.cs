using Dota2GSI;

namespace dotaTest
{
    class Program
    {
        const int PORT = 4000;
        static GameStateListener _gsl;

        static void Main(string[] args)
        {

            // Start the Game State Listener
            _gsl = new GameStateListener(PORT);

            // Create Config File / or try to!
            if (!_gsl.GenerateGSIConfigFile("DotaRTD"))
            {
                Console.WriteLine("Failed to generate Game State File File. Maybe it already Exists?");
            }

            // Create Handlers / Subscribe to Game Events That Are Needed

            // need the Game State
            _gsl.NewGameState += OnNewGameState;

            // _gsl.TeamDraftDetailsUpdated += TeamDraftDetailsUpdated; might not need this


            // Start the game state listener

            if (!_gsl.Start())
            {
                Console.WriteLine("Failed to Start the Game State Listener on" + PORT + ". Try Running as an Administrator");
                Console.ReadLine(); // indefinite wait till exit
                Environment.Exit(0);
            }

            // Assuming Successful launch of the Game State Listener
            Console.WriteLine("Listening for game integration calls...");
            Console.WriteLine("Press ESC to exit!");

            do
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(1000); // sleep for 1 second

                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        private static void OnNewGameState(GameState gs)
        {
            // Basic Game State Information Function
            Console.SetCursorPosition(0, 0);

            // Basic Information
            Console.WriteLine("Current Dota version: " + gs.Provider.Version);
            Console.WriteLine("Your steam name: " + gs.Player.LocalPlayer.Name);
            Console.WriteLine("Your dota account id: " + gs.Player.LocalPlayer.AccountID);
            Console.WriteLine("Current time (s): " + gs.Map.ClockTime);
            Console.WriteLine("Your Team: " + gs.Player.LocalPlayer.Team.ToString());

            Console.WriteLine();
            Console.WriteLine("Current Hero: " + gs.LocalPlayer.Hero.Name);
            Console.WriteLine("Level: " + gs.LocalPlayer.Hero.Level);
            Console.WriteLine("KDA: " + gs.Player.LocalPlayer.Kills + " / " + gs.Player.LocalPlayer.Deaths + " / " + gs.Player.LocalPlayer.Assists);
            Console.WriteLine("Current KillStreak: " + gs.Player.LocalPlayer.KillStreak);

            Console.WriteLine();
            Console.WriteLine("EFFICIENCY: ");
            Console.WriteLine("gpm: " + gs.Player.LocalPlayer.GoldPerMinute);
            Console.WriteLine("xpm: " + gs.Player.LocalPlayer.ExperiencePerMinute);
            Console.WriteLine("camps stacked: " + gs.Player.LocalPlayer.CampsStacked);

            Console.WriteLine();
            Console.WriteLine("LH/DN");
            Console.WriteLine("last hits: " + gs.Player.LocalPlayer.LastHits);
            Console.WriteLine("deny's: " + gs.Player.LocalPlayer.Denies);

            Console.WriteLine();
            Console.WriteLine("GOLD SPECIFICS: ");
            Console.WriteLine("Gold Gained From Creeps: " + gs.Player.LocalPlayer.GoldFromCreepKills);
            Console.WriteLine("Gold Gained From Heroes: " + gs.Player.LocalPlayer.GoldFromHeroKills);
            Console.WriteLine("Gold Gained From Passive Income: " + gs.Player.LocalPlayer.GoldFromIncome);
            Console.WriteLine("Gold Gained From Shared Kills: " + gs.Player.LocalPlayer.GoldFromShared);

            Console.WriteLine();
            Console.WriteLine("MISC: ");
            Console.WriteLine("Number of Commands Issued: " + gs.Player.LocalPlayer.CommandsIssued);
            Console.WriteLine("Buyback Cost: " + gs.LocalPlayer.Hero.BuybackCost);
            Console.WriteLine("Max Health: " + gs.LocalPlayer.Hero.MaxHealth);
            Console.WriteLine("Max Mana: " + gs.LocalPlayer.Hero.MaxMana);
            Console.WriteLine("Scepter? : " + gs.LocalPlayer.Hero.HasAghanimsScepterUpgrade);
            Console.WriteLine("Shard? : " + gs.LocalPlayer.Hero.HasAghanimsShardUpgrade);

            Console.WriteLine();
            Console.WriteLine("Position: (" + gs.LocalPlayer.Hero.Location.X + ", " + gs.LocalPlayer.Hero.Location.Y + ")");

            Console.WriteLine();
            Console.WriteLine("Inventory: ");
            Console.WriteLine("1: " + gs.Items.LocalPlayer.GetInventoryAt(0).Name);
            Console.WriteLine("2: " + gs.Items.LocalPlayer.GetInventoryAt(1).Name);
            Console.WriteLine("3: " + gs.Items.LocalPlayer.GetInventoryAt(2).Name);
            Console.WriteLine("4: " + gs.Items.LocalPlayer.GetInventoryAt(3).Name);
            Console.WriteLine("5: " + gs.Items.LocalPlayer.GetInventoryAt(4).Name);
            Console.WriteLine("6: " + gs.Items.LocalPlayer.GetInventoryAt(5).Name);
            Console.WriteLine("T: " + gs.Items.LocalPlayer.Teleport.Name);
            Console.WriteLine("N: " + gs.Items.LocalPlayer.Neutral.Name);

            Thread.Sleep(500);

        }

    }
}