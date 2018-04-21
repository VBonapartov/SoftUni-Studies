public class Axe : Weapon
{
    private const int AxeMinDamage = 5;
    private const int AxeMaxDamage = 10;
    private const int AxeSockets = 4;

    public Axe(string weaponName, WeaponRarity levelOfRarity)
        : base(weaponName, levelOfRarity, AxeMinDamage, AxeMaxDamage, AxeSockets)
    {
    }
}