namespace airplanes.entities.Equipment.Weapons;

public class Canons : Weapon
{
    public Canons() {
        this.MinDamage = 20;
        this.MaxDamage = 30;
        this.BonusHitChance = -10;
    }
    public override Int32 CalcDamage()
    {
        return Random.Shared.Next(MinDamage, MaxDamage);
    }

    public override Int32 GetBonusHitChance()
    {
        throw new NotImplementedException();
    }
}
