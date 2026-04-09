namespace airplanes.entities.Jets;

public class FighterJet : Jet
{
    private int bonusBomberDamage = 20;
    public FighterJet() {
        this.Health = 320;
        this.EvasionChance = 25;
    }

    public override void Attack(Jet targetJet)
    {
        if (Weapon is null) {
            throw new Exception("no weapon equipped");
        }
        if (!this.IsTargetHit(targetJet)) {
            Console.Write("Target missed");
            return;
        }

        int baseDamage = Weapon.CalcDamage();

        if (targetJet is BomberJet) {
            baseDamage += (baseDamage * 20) / 100;
        }
        targetJet.TakeDamage(baseDamage);
    }

    public override void TakeDamage(Int32 baseDamage) {
        base.TakeDamage(baseDamage);       
    }
}
