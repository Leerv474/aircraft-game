namespace airplanes.entities.Jets;

using airplanes.entities.Equipment.Ammunition;
using airplanes.entities.Equipment.Armor;
using airplanes.entities.Equipment.Weapons;

public abstract class Jet
{
    protected int health { get; set; }
    protected int evasionChance { get; set; }
    protected Weapon? weapon { get; set; }
    protected Armor? armor { get; set; }
    internal bool marked { get; set; } = false;
    internal bool turnSkip { get; set; } = false;
    internal bool armorPierced { get; set; } = false;
    private const int markedBonusHitChance = 15;

    public virtual void setWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public virtual void setArmor(Armor armor)
    {
        this.armor = armor;
    }

    public void setAmmunition(Ammunition ammo)
    {
        if (this.weapon is null)
        {
            throw new Exception("weapon isn't equipped");
        }
        this.weapon.setAmmo(ammo);
    }

    protected bool isTargetHit(Jet targetJet)
    {
        if (this.weapon is null)
        {
            throw new Exception("weapon isn't equipped");
        }
        int hitChance = this.weapon.getBonusHitChance();
        if (targetJet.marked)
        {
            hitChance += markedBonusHitChance;
            this.marked = false;
        }
        if (targetJet.armor is HeavyArmor)
        {
            hitChance += HeavyArmor.evasionPenalty;
        }

        this.evasionChance -= hitChance;

        int rnd = Random.Shared.Next(0, 100);
        if (rnd >= evasionChance)
        {
            return true;
        }

        return false;
    }

    public virtual void attack(Jet targetJet)
    {
        if (weapon is null)
        {
            throw new Exception("no weapon equipped");
        }
        if (!this.isTargetHit(targetJet))
        {
            Console.Write("Target missed");
            return;
        }

        weapon.applyDeduff(targetJet);
        int baseDamage = weapon.calcDamage();

        targetJet.takeDamage(baseDamage);
        if (weapon is Canons)
        {
            if (!this.isTargetHit(targetJet))
            {
                Console.Write("Target missed");
                return;
            }
            weapon.applyDeduff(targetJet);
            baseDamage = weapon.calcDamage();

            targetJet.takeDamage(baseDamage);
        }
    }

    public virtual void takeDamage(int baseDamage)
    {
        if (armor is null)
        {
            throw new Exception("no armor equipped");
        }
        int finalDamage = baseDamage;

        if (!this.armorPierced)
        {
            finalDamage = (baseDamage * this.armor.getProtectionValue()) / 100;
        }
        this.health -= finalDamage;
    }


    public override string ToString()
    {
        return $"---Jet type: {this.GetType().Name}---\n{this.weapon?.ToString()}\n{this.armor?.ToString()}\n---";
    }
}
