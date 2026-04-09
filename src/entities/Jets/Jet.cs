namespace airplanes.entities.Jets;

using airplanes.entities.Equipment.Ammunition;
using airplanes.entities.Equipment.Armor;
using airplanes.entities.Equipment.Weapons;

public abstract class Jet
{
    protected Int32 Health { get; set; }
    protected Int32 EvasionChance { get; set; }
    protected Weapon? Weapon { get; set; }
    protected Armor? Armor { get; set; }

    internal Boolean Marked { get; set; } = false;
    internal Boolean TurnSkip { get; set; } = false;
    internal Boolean ArmorPierced { get; set; } = false;
    private const Int32 MarkedBonusHitChance = 15;

    public virtual void SetWeapon(Weapon weapon)
    {
        this.Weapon = weapon;
    }

    public virtual void SetArmor(Armor armor)
    {
        this.Armor = armor;
    }

    public void SetAmmunition(Ammunition ammo)
    {
        if (this.Weapon is null)
        {
            throw new Exception("weapon isn't equipped");
        }
        this.Weapon.SetAmmo(ammo);
    }

    protected Boolean IsTargetHit(Jet targetJet)
    {
        if (this.Weapon is null)
        {
            throw new Exception("weapon isn't equipped");
        }
        int hitChance = this.Weapon.GetBonusHitChance();
        if (targetJet.Marked)
        {
            hitChance += MarkedBonusHitChance;
            this.Marked = false;
        }
        if (targetJet.Armor is HeavyArmor)
        {
            hitChance += HeavyArmor.EvasionPenalty;
        }

        this.EvasionChance -= hitChance;

        int rnd = Random.Shared.Next(0, 100);
        if (rnd >= EvasionChance)
        {
            return true;
        }

        return false;
    }

    public virtual void Attack(Jet targetJet)
    {
        if (Weapon is null)
        {
            throw new Exception("no weapon equipped");
        }
        this.Weapon.SpendAmmo();
        if (!this.IsTargetHit(targetJet))
        {
            Console.Write("Target missed");
            return;
        }

        Weapon.ApplyDeduff(targetJet);
        int baseDamage = Weapon.CalcDamage();

        targetJet.TakeDamage(baseDamage);
        if (Weapon is Canons)
        {
            if (!this.IsTargetHit(targetJet))
            {
                Console.Write("Target missed");
                return;
            }
            Weapon.ApplyDeduff(targetJet);
            baseDamage = Weapon.CalcDamage();

            targetJet.TakeDamage(baseDamage);
        }
    }

    public virtual void TakeDamage(Int32 baseDamage)
    {
        if (Armor is null)
        {
            throw new Exception("no armor equipped");
        }
        int finalDamage = baseDamage;

        if (!this.ArmorPierced)
        {
            finalDamage = (baseDamage * this.Armor.GetProtectionValue()) / 100;
        }
        this.Health -= finalDamage;
    }


    public override string ToString()
    {
        return $"---Jet type: {this.GetType().Name}---\n{this.Weapon?.ToString()}\n{this.Armor?.ToString()}\n---";
    }
}
