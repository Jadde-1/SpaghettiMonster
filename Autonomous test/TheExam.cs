namespace TheExam;
using SpaghettiMonster.ArenaEngine;
using SpaghettiMonster.Gladiators;
using SpaghettiMonster.Weapons;

public class TheExam
{
    [Fact]
    public void Weapon_CreatingWepon_AccesVariables()
    {
        Weapon weapon = new Weapon("Storm breaker", 10, WeaponType.Axe);
        Assert.Equal(weapon.Name, "Storm breaker");
        Assert.Equal(weapon.BaseDamage, 10);
        Assert.Equal(weapon.Type, WeaponType.Axe);

    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(-99999)]


    public void Weapon_CreateWeaponWithInvalidDamage_ThrowException(int test)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Weapon("Storm breaker", test, WeaponType.Axe));

    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-9999)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(9999)]

    public void Arena_SetInvalidArmorStatToGetHealth_SetDamageTOZero(int armor)
    {
        ArenaEngine engine = new ArenaEngine();
        Gladiator p1 = new Gladiator("p1");
        Gladiator p2 = new Gladiator("p1");

        p1.EquippedWeapon = new Weapon("Axe", 25, WeaponType.Axe);
        p2.EquippedWeapon = new Weapon("Axe", 25, WeaponType.Axe);

        p1.Armor = armor;
        engine.ExecuteTurn(p1, p2);

        if (engine.ActualDamage >= 1)
        {
        } else
        {
            Assert.Fail("Value went under 1. ");
        }
    }


    [Fact]

    public void Arena_TestHeavyAttactWithAxe_Range()
    {
        bool doubleDamage = false;
        int rounds = 1000;
        for (int i = 0; i < rounds; i++)
        {

            ArenaEngine engine = new ArenaEngine();
            Gladiator p1 = new Gladiator("p1");
            Gladiator p2 = new Gladiator("p1");

            p1.EquippedWeapon = new Weapon("Axe", 25, WeaponType.Axe);
            p2.EquippedWeapon = new Weapon("Axe", 25, WeaponType.Axe);

            engine.ExecuteTurn(p1, p2);
            if (engine.ActualDamage > 39)
            {
                doubleDamage = true;
                break;
            }
        }

        if (doubleDamage == false)
        {
            Assert.Fail("Over " + rounds + " rounds and it didint get double damage once" );
        }

    }


}

