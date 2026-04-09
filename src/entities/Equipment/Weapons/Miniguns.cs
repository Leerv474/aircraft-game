namespace airplanes.entities.Equipment.Weapons;

public class Miniguns : Weapon
{
    public Miniguns() {
        this.MinDamage = 10;
        this.MaxDamage = 15;
        this.BonusHitChance = 15;
    }
    public override Int32 CalcDamage()
    {
        return base.CalcDamage();
    }

    public override Int32 GetBonusHitChance()
    {
        return base.GetBonusHitChance();
    }
}
