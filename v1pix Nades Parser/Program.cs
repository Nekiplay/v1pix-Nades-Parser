using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace v1pix_Nades_Parser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int movements = 0;

            int molotovs = 0;
            int smokes = 0;
            int he = 0;
            int flashbang = 0;
            Console.Write("Folder path: ");
            string folder_path = Console.ReadLine();
            var files = Directory.GetFiles(folder_path);
            foreach (string path in files)
            {
                FileInfo file = new FileInfo(path);
                if (file.Extension == "")
                {
                    string json_raw = File.ReadAllText(path);
                    JObject jobject = JObject.Parse(json_raw);
                    var values = jobject.Values();
                    foreach (var val in values)
                    {
                        for (int i = 0; i < val.Count(); i++)
                        {
                            string weapon = val[i]["weapon"].ToString();
                            if (weapon == "weapon_knife_movement")
                            {
                                movements += 1;
                            }
                            else if (weapon == "weapon_flashbang")
                            {
                                flashbang += 1;
                            }
                            else if (weapon == "weapon_hegrenade")
                            {
                                he += 1;
                            }
                            else if (weapon == "weapon_smokegrenade")
                            {
                                smokes += 1;
                            }
                            else if (weapon == "weapon_molotov")
                            {
                                molotovs += 1;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Total: " + (molotovs + he + smokes + flashbang + movements));
            Console.WriteLine("Molotovs: " + molotovs);
            Console.WriteLine("HE: " + he);
            Console.WriteLine("Smokes: " + smokes);
            Console.WriteLine("Flashbangs: " + flashbang);
            Console.WriteLine("Movements: " + movements);
            Console.ReadLine();
        }
    }
}
