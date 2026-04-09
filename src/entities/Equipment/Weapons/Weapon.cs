namespace airplanes.entities.Equipment.Weapons;

using airplanes.entities.Equipment.Ammunition;
using airplanes.entities.Jets;

// change evasion chance
// calc damage
// handles special properties

public abstract class Weapon
{
    protected Int32 MinDamage { get; set; }
    protected Int32 MaxDamage { get; set; }
    protected Int32 BonusHitChance { get; set; }
    protected Ammunition? Ammunition { get; set; }
    protected Int32 AmmoLeft {get; set;} = 30;

    public virtual Int32 CalcDamage()
    {
        if (Ammunition is null)
        {
            throw new Exception("no ammunition equipped");
        }
        int damage = Random.Shared.Next(MinDamage, MaxDamage);
        damage = Ammunition.ApplyBonusDamage(damage);
        return damage;
    }

    public virtual Int32 GetBonusHitChance()
    {
        return BonusHitChance;
    }

    internal virtual void SetAmmo(Ammunition ammo)
    {
        this.Ammunition = ammo;
    }

    public void ApplyDeduff(Jet targetJet)
    {
        if (Ammunition is null)
        {
            throw new Exception("no ammunition equipped");
        }
        this.Ammunition.ApplyDebuff(targetJet);
    }

    internal void SpendAmmo()
    {
        if (this.AmmoLeft == 0) {
            throw new Exception("out of ammo");
        }
        this.AmmoLeft--;
    }

    public override string ToString()
    {
        return $"Weapon type: {this.GetType().Name}\n{this.Ammunition?.ToString()}";
    }
}
