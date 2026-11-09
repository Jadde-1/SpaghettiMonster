using System;
using System.Collections.Generic;

public enum WeaponType { Sword, Axe, Staff }

public class Weapon
{
    public string Name { get; set; }
    public int BaseDamage { get; set; }
    public WeaponType Type { get; set; }

    public Weapon(string name, int dmg, WeaponType type)
    {
        if (dmg < 0)
        {
            Console.WriteLine("FEJL: Skade må ikke være negativ! Sætter den til 1.");
            BaseDamage = 1;
        }
        else
        {
            BaseDamage = dmg;
        }
        Name = name;
        Type = type;
    }
}

public class Gladiator
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Armor { get; set; }
    public Weapon EquippedWeapon { get; set; }

    public Gladiator()
    {
        Console.Write("Indtast navn på ny gladiator: ");
        Name = Console.ReadLine();
        Health = 100;
        Armor = 5;
        Console.WriteLine($"Gladiatoren {Name} træder ind på arenaen med {Health} HP!");
    }

    public void EquipWeapon()
    {
        Console.WriteLine("Vælg våben: 1. Rustent Sværd (15 dmg), 2. Tung Økse (25 dmg)");
        string choice = Console.ReadLine();
        if (choice == "1") EquippedWeapon = new Weapon("Rustent Sværd", 15, WeaponType.Sword);
        else EquippedWeapon = new Weapon("Tung Økse", 25, WeaponType.Axe);
        Console.WriteLine($"{Name} har nu valgt {EquippedWeapon.Name}!");
    }
}

public class ArenaEngine
{
    public List<string> BattleLog = new List<string>();

    public void ExecuteTurn(Gladiator attacker, Gladiator defender, int calculatedDamage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n---> {attacker.Name} angriber {defender.Name} med {attacker.EquippedWeapon.Name}!");
        Console.ResetColor();

        int actualDamage = calculatedDamage - defender.Armor;
        if (actualDamage < 0) actualDamage = 0;

        defender.Health -= actualDamage;
        BattleLog.Add($"{attacker.Name} gjorde {actualDamage} skade på {defender.Name}.");

        Console.WriteLine($"{defender.Name} mistede {actualDamage} liv og har {defender.Health} HP tilbage.");

        if (defender.Health <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"KAMPEN ER SLUT! {attacker.Name} har vundet!");
            Console.ResetColor();
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== VELKOMMEN TIL GLADIATOR ARENAEN ===");
        Gladiator p1 = new Gladiator();
        p1.EquipWeapon();

        Gladiator p2 = new Gladiator();
        p2.EquipWeapon();

        ArenaEngine engine = new ArenaEngine();
        Random rng = new Random();

        while (p1.Health > 0 && p2.Health > 0)
        {
            Console.WriteLine("\nTryk ENTER for næste runde...");
            Console.ReadLine();

            // Spiller 1 angriber: Beregn om det er et Critical Hit
            int dmg1 = p1.EquippedWeapon.BaseDamage;
            if (p1.EquippedWeapon.Type == WeaponType.Axe && rng.Next(0, 100) < 25)
            {
                Console.WriteLine("CRITICAL HIT MED ØKSEN!");
                dmg1 *= 2;
            }
            engine.ExecuteTurn(p1, p2, dmg1);

            if (p2.Health <= 0) break;

            // Spiller 2 angriber
            int dmg2 = p2.EquippedWeapon.BaseDamage;
            if (p2.EquippedWeapon.Type == WeaponType.Axe && rng.Next(0, 100) < 25)
            {
                Console.WriteLine("CRITICAL HIT MED ØKSEN!");
                dmg2 *= 2;
            }
            engine.ExecuteTurn(p2, p1, dmg2);
        }

        Console.WriteLine("\n--- KAMP-LOG ---");
        foreach (var entry in engine.BattleLog)
        {
            Console.WriteLine(entry);
        }
    }
}