namespace airplanes.entities.Equipment.Weapons;
using airplanes.entities.Equipment.Ammunition;

// change evasion chance
// calc damage
// handles special properties

public abstract class Weapon
{
    protected Int32 MinDamage { get; set; }
    protected Int32 MaxDamage { get; set; }
    protected Int32 BonusHitChance { get; set; }

    public virtual Int32 CalcDamage()
    {
        int damage = Random.Shared.Next(MinDamage, MaxDamage);
        return damage;
    }

    public virtual Int32 GetBonusHitChance()
    {
        return BonusHitChance;
    }

    public override string ToString()
    {
        return $"Weapon type: {this.GetType().Name}";
    }

    public virtual Boolean AmmoIsCompatible(Ammunition ammo) {
        return true;
    }
}
