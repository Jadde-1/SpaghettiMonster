using SpaghettiMonster.ArenaEngine;
using SpaghettiMonster.Gladiators;
using SpaghettiMonster.Weapons;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        string Name = "";
        Console.WriteLine("=== VELKOMMEN TIL GLADIATOR ARENAEN ===");

        Console.Write("Indtast navn på ny gladiator: ");
        Name = Console.ReadLine();
        Gladiator p1 = new Gladiator(Name);
        Console.WriteLine($"Gladiatoren {p1.Name} træder ind på arenaen med {p1.Health} HP!");
        EquipWeapon(p1);

        Console.Write("Indtast navn på ny gladiator: ");
        Name = Console.ReadLine();
        Gladiator p2 = new Gladiator(Name);
        Console.WriteLine($"Gladiatoren {p2.Name} træder ind på arenaen med {p1.Health} HP!");
        EquipWeapon(p2);


        ArenaEngine engine = new ArenaEngine();
        Random rng = new Random();

        while (p1.Health > 0 && p2.Health > 0)
        {
            Console.WriteLine("\nTryk ENTER for næste runde...");
            Console.ReadLine();

            StartTurn(p1, p2);
            engine.ExecuteTurn(p1, p2);
            EndTurn(p1, p2, engine.ActualDamage);

            if (p2.Health <= 0) break;

            StartTurn(p2, p1);
            engine.ExecuteTurn(p2, p1);
            EndTurn(p2,p1, engine.ActualDamage);

        }

        Console.WriteLine("\n--- KAMP-LOG ---");
        foreach (var entry in engine.BattleLog)
        {
            Console.WriteLine(entry);
        }

        void EquipWeapon(Gladiator player)
        {
            Console.WriteLine("Vælg våben: 1. Rustent Sværd (15 dmg), 2. Tung Økse (25 dmg)");
            string choice = Console.ReadLine();
            try
            {
                player.EquipWeapon(choice);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"{player.Name} har nu valgt {player.EquippedWeapon.Name}!");
        }
    }




    private static void StartTurn(Gladiator attacker, Gladiator defender)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n---> {attacker.Name} angriber {defender.Name} med {attacker.EquippedWeapon.Name}!");
        Console.ResetColor();

    }

    private static void EndTurn(Gladiator attacker, Gladiator defender, int actualDamage)
    {
        Console.WriteLine($"{defender.Name} mistede {actualDamage} liv og har {defender.Health} HP tilbage.");

        if (defender.Health <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"KAMPEN ER SLUT! {attacker.Name} har vundet!");
            Console.ResetColor();
        }
    }

}