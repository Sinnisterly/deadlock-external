using deadlock.Drawing;
using deadlock.external;

namespace deadlock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!Memory.Initialize())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("game not found, please run the game before opening the program");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
                Console.Beep();
            new Thread(() =>
            {
                while (true)
                {
                    PrintInfo();
                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.D1)
                        enable_boxes = !enable_boxes;
                    else if (key == ConsoleKey.D2)
                        enable_bones = !enable_bones;
                    else if (key == ConsoleKey.D3)
                        enable_healthbar = !enable_healthbar;
                    else if (key == ConsoleKey.D4)
                        enable_text = !enable_text;
                    else if (key == ConsoleKey.D5)
                        enable_radar = !enable_radar;
                    else
                        continue;
                }
            }).Start();
            new Overlay(); // sync
        }

        static void PrintInfo()
        {
            Console.Title = "Loathe's Deadlock External ESP";
            Console.Clear();
            PrintField("1. Enemy Boxes", enable_boxes);
            PrintField("2. Enemy Bones", enable_bones);
            PrintField("3. Health Bar", enable_healthbar);
            PrintField("4. Enemy Name", enable_text);
            PrintField("5. Radar", enable_radar);
        }

        static void PrintField(string name, bool enabled)
        {
            Console.Write($"{name}:\t{(name.Length >= 8 ? "" : "\t")}");
            Console.ForegroundColor = enabled ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(enabled.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        public static bool enable_boxes = false;
        public static bool enable_bones = false;
        public static bool enable_healthbar = false;
        public static bool enable_text = false;
        public static bool enable_radar = false;
    }
}
