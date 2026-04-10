namespace airplanes.entities.Jets;

using airplanes.entities.Equipment.Ammunition;
using airplanes.entities.Equipment.Armor;
using airplanes.entities.Equipment.Weapons;
using airplanes.types;

public abstract class Jet
{
    private Int32 ID { get; set; }
    protected Int32 Health { get; set; }
    protected Int32 EvasionChance { get; set; }
    protected Weapon? PrimaryWeapon { get; set; }
    protected Weapon? SecondaryWeapon { get; set; }
    protected Armor? Armor { get; set; }
    protected Ammunition? Ammunition { get; set; }
    protected JetType Type { get; set; }

    internal Boolean Marked { get; set; } = false;
    internal Boolean TurnSkip { get; set; } = false;
    internal Boolean ArmorPierced { get; set; } = false;
    private const Int32 MarkedBonusHitChance = 15;
    private Int32 AmmunitionLeft { get; set; } = 30;

    public Int32 GetID()
    {
        return this.ID;
    }

    public virtual void SetPrimaryWeapon(Weapon weapon)
    {
        this.PrimaryWeapon = weapon;
    }

    public virtual void SetSecondaryWeapon(Weapon weapon)
    {
        this.SecondaryWeapon = weapon;
    }

    public virtual void SetArmor(Armor armor)
    {
        this.Armor = armor;
    }

    public void SetAmmunition(Ammunition ammo)
    {
        this.Ammunition = ammo;
    }

    private void ApplyDeduff(Jet targetJet)
    {
        if (Ammunition is null)
        {
            throw new Exception("no ammunition equipped");
        }
        this.Ammunition.ApplyDebuff(targetJet);
    }

    protected Boolean IsTargetHit(Jet targetJet, Weapon weaponUsed)
    {
        int hitChance = weaponUsed.GetBonusHitChance();
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
        if (PrimaryWeapon is null)
        {
            throw new Exception("no primary weapon equipped");
        }
        if (SecondaryWeapon is null)
        {
            throw new Exception("no secondary weapon equipped");
        }
        this.Shoot(targetJet, this.PrimaryWeapon);
        this.Shoot(targetJet, this.SecondaryWeapon);
    }

    private void firingCapabilityCheck(Weapon weaponUsed)
    {
        if (Ammunition is null)
        {
            throw new Exception("no ammunition equipped");
        }
        if (Ammunition is TracerRounds && weaponUsed is RocketLaunchers)
        {
            throw new Exception("incompatible ammo type");
        }
        if (this.AmmunitionLeft == 0)
        {
            throw new Exception("out of ammo");
        }
    }

    protected virtual void Shoot(Jet targetJet, Weapon weaponUsed)
    {
        firingCapabilityCheck(weaponUsed);
        this.AmmunitionLeft--;
        if (!this.IsTargetHit(targetJet, weaponUsed))
        {
            return;
        }

        this.ApplyDeduff(targetJet);
        int baseDamage = weaponUsed.CalcDamage();
        this.Ammunition?.ApplyBonusDamage(baseDamage);

        targetJet.TakeDamage(baseDamage);

        if (weaponUsed is Canons)
        {
            if (!this.IsTargetHit(targetJet, weaponUsed))
            {
                Console.Write("Target missed");
                return;
            }
            this.ApplyDeduff(targetJet);
            baseDamage = weaponUsed.CalcDamage();

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
        // return $"---Jet type: {this.GetType().Name}---\n{this.PrimaryWeapon?.ToString()}\n{this.SecondaryWeapon?.ToString()}\n{this.Ammunition?.ToString()}\n{this.Armor?.ToString()}\n---";
        return $"---Jet type: {this.GetType().Name}---\nID: {this.ID}\nHealth: {this.Health}\n---";
    }
}
