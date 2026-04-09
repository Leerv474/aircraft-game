namespace airplanes.entities.Equipment.Weapons;

public class Canons : Weapon
{
    public Canons() {
        this.minDamage = 20;
        this.maxDamage = 30;
        this.bonusHitChance = -10;
    }
    public override int calcDamage()
    {
        return Random.Shared.Next(minDamage, maxDamage);
    }

    public override int getBonusHitChance()
    {
        throw new NotImplementedException();
    }
}
