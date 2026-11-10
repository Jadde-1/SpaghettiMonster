using GameLibrary.BattleLog;
using SpaghettiMonster.Gladiators;
using SpaghettiMonster.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaghettiMonster.ArenaEngine
{
    public class ArenaEngine
    {
        public IBattleLog BattleLog;
        public int ActualDamage {  get; private set; }

        public ArenaEngine(IBattleLog battleLog)
        {

        }

        public void ExecuteTurn(Gladiator attacker, Gladiator defender, IBattleLog logger)
        {
            ActualDamage = attacker.EquippedWeapon.BaseDamage;
            Random rng = new Random();
            if (attacker.EquippedWeapon.Type == WeaponType.Axe && rng.Next(0, 100) < 25)
            {

                Console.WriteLine("CRITICAL HIT MED ØKSEN!");
                ActualDamage *= 2;
            }
            ActualDamage = ActualDamage - defender.Armor;
            if (ActualDamage < 0) ActualDamage = 0;

            defender.Health -= ActualDamage;
            BattleLog.Add($"{attacker.Name} gjorde {ActualDamage} skade på {defender.Name}.");

            
        }
    }
}
