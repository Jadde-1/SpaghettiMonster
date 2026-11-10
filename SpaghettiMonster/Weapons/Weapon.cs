using System;
using System.Collections.Generic;
using System.Text;

namespace SpaghettiMonster.Weapons
{
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
                BaseDamage = 1;
                throw new ArgumentOutOfRangeException("FEJL: Skade må ikke være negativ! Sætter den til 1."); 
            }
            else
            {
                BaseDamage = dmg;
            }
            Name = name;
            Type = type;
        }
    }
}
