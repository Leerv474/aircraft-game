namespace airplanes.entities.Equipment.Weapons;

public class Miniguns : Weapon
{
    public Miniguns() {
        this.minDamage = 10;
        this.maxDamage = 15;
        this.bonusHitChance = 15;
    }
    public override int calcDamage()
    {
        return base.calcDamage();
    }

    public override int getBonusHitChance()
    {
        return base.getBonusHitChance();
    }
}
