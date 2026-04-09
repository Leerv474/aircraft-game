namespace airplanes.entities.Equipment.Weapons;

using airplanes.entities.Equipment.Ammunition;

public class RocketGun : Weapon
{
    private int cooldownCnt { get; set; } = 0;

    public RocketGun()
    {
        this.minDamage = 10;
        this.maxDamage = 15;
        this.bonusHitChance = 1000;
    }

    public bool onCooldown()
    {
        if (this.cooldownCnt == 0)
        {
            this.cooldownCnt++;
            return false;
        }
        this.cooldownCnt--;
        return true;
    }

    public override int calcDamage()
    {
        return base.calcDamage();
    }

    public override int getBonusHitChance()
    {
        return base.getBonusHitChance();
    }

    internal override void setAmmo(Ammunition ammunition)
    {
        if (ammunition is TracerRounds)
        {
            throw new Exception("tracer rounds can't be used by rocket gun");
        }
        this.ammunition = ammunition;
    }
}
