namespace airplanes.entities.Equipment.Weapons;

using airplanes.entities.Equipment.Ammunition;
using airplanes.entities.Jets;

// change evasion chance
// calc damage
// handles special properties

public abstract class Weapon
{
    protected int minDamage { get; set; }
    protected int maxDamage { get; set; }
    protected int bonusHitChance { get; set; }
    protected Ammunition? ammunition { get; set; }

    public virtual int calcDamage()
    {
        if (ammunition is null)
        {
            throw new Exception("no ammunition equipped");
        }
        int damage = Random.Shared.Next(minDamage, maxDamage);
        damage = ammunition.applyBonusDamage(damage);
        return damage;
    }

    public virtual int getBonusHitChance()
    {
        return bonusHitChance;
    }

    internal virtual void setAmmo(Ammunition ammo)
    {
        this.ammunition = ammo;
    }

    public void applyDeduff(Jet targetJet)
    {
        if (ammunition is null)
        {
            throw new Exception("no ammunition equipped");
        }
        this.ammunition.applyDebuff(targetJet);
    }

    public override string ToString()
    {
        return $"Weapon type: {this.GetType().Name}\n{this.ammunition?.ToString()}";
    }
}
