namespace TheExam;
using SpaghettiMonster.Weapons;

public class UnitTest1
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



}

