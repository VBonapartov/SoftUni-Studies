public class Knife : Weapon
{
    private const int KnifeMinDamage = 3;
    private const int KnifeMaxDamage = 4;
    private const int KnifeSockets = 2;

    public Knife(string knifeName, WeaponRarity levelOfRarity)
        : base(knifeName, levelOfRarity, KnifeMinDamage, KnifeMaxDamage, KnifeSockets)
    {
    }
}