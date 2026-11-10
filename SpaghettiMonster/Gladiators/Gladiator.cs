using System;
using System.Collections.Generic;
using System.Text;
using SpaghettiMonster.Weapons;

namespace SpaghettiMonster.Gladiators
{
    public class Gladiator
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public Weapon EquippedWeapon { get; set; }

        public Gladiator(string name)
        {
            Name = name;
            Health = 100;
            Armor = 5;
        }

        public void EquipWeapon(string choice)
        {
            if (choice == "1") EquippedWeapon = new Weapon("Rustent Sværd", 15, WeaponType.Sword);
            else EquippedWeapon = new Weapon("Tung Økse", 25, WeaponType.Axe);
        }
    }

}