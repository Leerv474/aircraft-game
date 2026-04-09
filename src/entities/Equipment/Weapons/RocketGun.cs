namespace airplanes.entities.Equipment.Weapons;

using airplanes.entities.Equipment.Ammunition;

public class RocketLaunchers : Weapon
{
    private Int32 CooldownCount { get; set; } = 0;

    public RocketLaunchers()
    {
        this.MinDamage = 10;
        this.MaxDamage = 15;
        this.BonusHitChance = 1000;
    }

    public Boolean OnCooldown()
    {
        if (this.CooldownCount == 0)
        {
            this.CooldownCount++;
            return false;
        }
        this.CooldownCount--;
        return true;
    }

    public override Int32 CalcDamage()
    {
        return base.CalcDamage();
    }

    public override Int32 GetBonusHitChance()
    {
        return base.GetBonusHitChance();
    }

    internal override void SetAmmo(Ammunition ammunition)
    {
        if (ammunition is TracerRounds)
        {
            throw new Exception("tracer rounds can't be used by rocket gun");
        }
        this.Ammunition = ammunition;
    }
}
