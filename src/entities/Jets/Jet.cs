namespace airplanes.entities.Jets;

using airplanes.entities.Equipment.Ammunition;
using airplanes.entities.Equipment.Armor;
using airplanes.entities.Equipment.Weapons;
using airplanes.entities.FiredShots;
using airplanes.types;

public abstract class Jet
{
    protected Int32 Health { get; set; }
    protected Int32 EvasionChance { get; set; }
    protected Weapon? PrimaryWeapon { get; set; }
    protected Weapon? SecondaryWeapon { get; set; }
    public Armor? Armor { get; private set;}
    protected Ammunition? Ammunition { get; set; }
    protected JetType Type { get; set; }

    public Boolean Marked { get; set; } = false;
    internal Boolean TurnSkip { get; set; } = false;
    internal Boolean ArmorPierced { get; set; } = false;
    public const Int32 MarkedBonusHitChance = 15;
    private Int32 AmmunitionLeft { get; set; } = 30;

    public Boolean IsDead()
    {
        return this.Health <= 0;
    }

    public Int32 GetCurrentHealth() {
        return this.Health;
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

    public Weapon GetPrimaryWeapon()
    {
        if (this.PrimaryWeapon is null)
        {
            throw new Exception("no primary weapon equipped");
        }
        return this.PrimaryWeapon;
    }

    public Weapon GetSecondaryWeapon()
    {
        if (this.PrimaryWeapon is null)
        {
            throw new Exception("no secondary weapon equipped");
        }
        return this.PrimaryWeapon;
    }

    public virtual Int32 GetArmorEvasionPenalty()
    {
        if (this.Armor is null)
        {
            throw new Exception("no armor equipped");
        }
        return this.Armor.GetEvasionPenalty();
    }

    public virtual Int32 GetEvasionChance()
    {
        return this.EvasionChance;
    }

    public virtual List<FiredShot> Attack(Jet targetJet)
    {
        if (PrimaryWeapon is null)
        {
            throw new Exception("no primary weapon equipped");
        }
        List<FiredShot> firedShots = new();
        var shot = this.Shoot(targetJet, this.PrimaryWeapon);
        if (shot is not null)
        {
            firedShots.Add(shot);
        }

        if (this.PrimaryWeapon is Canons) {
            shot = this.Shoot(targetJet, this.PrimaryWeapon);
            if (shot is not null)
            {
                firedShots.Add(shot);
            }
        }

        if (SecondaryWeapon is null)
        {
            throw new Exception("no secondary weapon equipped");
        }
        shot = this.Shoot(targetJet, this.SecondaryWeapon);
        if (shot is not null)
        {
            firedShots.Add(shot);
        }
        if (this.SecondaryWeapon is Canons) {
            shot = this.Shoot(targetJet, this.SecondaryWeapon);
            if (shot is not null)
            {
                firedShots.Add(shot);
            }
        }
        return firedShots;
    }

    private Boolean IsCapableOfFiring(Weapon weaponUsed)
    {
        bool isCapable =
            Ammunition is null
            || Ammunition is TracerRounds && weaponUsed is RocketLaunchers
            || this.AmmunitionLeft == 0;
        if (isCapable)
        {
            return false;
        }
        return true;
    }

    protected virtual FiredShot? Shoot(Jet target, Weapon weaponUsed)
    {
        if (!this.IsCapableOfFiring(weaponUsed))
        {
            return null;
        }
        this.AmmunitionLeft--;

        return new FiredShot(this, weaponUsed, target, this.Ammunition);
    }

    public virtual void TakeDamage(Int32 damage)
    {
        this.Health -= damage;
    }

    public override string ToString()
    {
        // return $"---Jet type: {this.GetType().Name}---\n{this.PrimaryWeapon?.ToString()}\n{this.SecondaryWeapon?.ToString()}\n{this.Ammunition?.ToString()}\n{this.Armor?.ToString()}\n---";
        return $"---Jet type: {this.GetType().Name}---\nHealth: {this.Health}\n---";
    }
}
