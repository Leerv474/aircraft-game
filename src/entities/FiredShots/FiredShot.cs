using airplanes.entities.Jets;
using airplanes.entities.Equipment.Weapons;
using airplanes.entities.Equipment.Ammunition;
using airplanes.types;

namespace airplanes.entities.FiredShots;

public class FiredShot {
    private Jet AttakingJet;
    private Weapon WeaponUsed;
    private Jet TargetedJet;
    private Ammunition Ammunition;

    public FiredShot(Jet attackingJet, Weapon weaponUsed, Jet targetedJet, Ammunition ammunition) {
        this.AttakingJet =  attackingJet;
        this.TargetedJet = targetedJet;
        this.WeaponUsed = weaponUsed;
        this.Ammunition = ammunition;
    }

    public Boolean IsTargetHit() {
        int hitChance = this.WeaponUsed.GetBonusHitChance();
        if (TargetedJet.Marked) {
            hitChance += Jet.MarkedBonusHitChance;
            TargetedJet.Marked = false;
        }
        hitChance += this.TargetedJet.GetArmorEvasionPenalty();
        hitChance -= this.TargetedJet.GetEvasionChance();

        int rnd = Random.Shared.Next(0, 100);
        if (rnd <= hitChance)
        {
            return true;
        }

        return false;
    }

    public void DealDamage() {
        int damage = this.WeaponUsed.CalcDamage();
        damage += this.Ammunition.GetBonusDamage();

        Ammunition.ApplyDebuff(TargetedJet);

        if (IsTargetHit()) {
            return;
        }

        int damageReduction = this.TargetedJet.Armor.GetProtectionValue();
        if (this.Ammunition is HeapRounds) {
            damageReduction += 50;
        }

        damage -= (damage * damageReduction) / 100;
        
        this.TargetedJet.TakeDamage(damage);
    }
}
