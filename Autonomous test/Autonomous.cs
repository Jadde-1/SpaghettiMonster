using SpaghettiMonster.Gladiators;
using System.Xml.Linq;
using SpaghettiMonster.Weapons;
using SpaghettiMonster.ArenaEngine;

namespace Autonomous_test;

public class SelfRunningTest

{
    [Fact]
    public void Program_RunningProgram_NoErrors()
    {// https://stackoverflow.com/questions/9417213/how-do-i-check-no-exception-occurred-in-my-mstest-unit-test
        try
        {
            ArenaEngine engine = new ArenaEngine();

            Gladiator p1 = new Gladiator("p1");
            Gladiator p2 = new Gladiator("p2");

            p1.EquippedWeapon = new Weapon("Axe", 25, WeaponType.Axe);
            p2.EquippedWeapon = new Weapon("Axe", 25, WeaponType.Axe);

            while (p1.Health > 0 && p2.Health > 0)
            {
     
                engine.ExecuteTurn(p1, p2);

                if (p2.Health <= 0) break;

                engine.ExecuteTurn(p2, p1);

            }
        }
        catch (Exception ex)
        {
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

        }
    }
}

