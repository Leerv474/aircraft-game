namespace airplanes.entities.Jets;
using airplanes.entities.Equipment.Weapons;
using airplanes.types;

public class FighterJet : Jet
{
    private int BonusBomberDamage = 20;

    public FighterJet()
    {
        this.Health = 320;
        this.EvasionChance = 25;
        this.Type = JetType.Fighter;
    }

    protected override void Shoot(Jet targetJet, Weapon weaponUsed)
    {
        if (!this.IsTargetHit(targetJet, weaponUsed))
        {
            return;
        }

        int baseDamage = weaponUsed.CalcDamage();

        if (targetJet is BomberJet)
        {
            baseDamage += (baseDamage * this.BonusBomberDamage) / 100;
        }
        targetJet.TakeDamage(baseDamage);
    }

    public override void TakeDamage(Int32 baseDamage)
    {
        base.TakeDamage(baseDamage);
    }
}
