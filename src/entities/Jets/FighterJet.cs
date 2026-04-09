namespace airplanes.entities.Jets;

public class FighterJet : Jet
{
    private int bonusBomberDamage = 20;
    public FighterJet() {
        this.health = 320;
        this.evasionChance = 25;
    }

    public override void attack(Jet targetJet)
    {
        if (weapon is null) {
            throw new Exception("no weapon equipped");
        }
        if (!this.isTargetHit(targetJet)) {
            Console.Write("Target missed");
            return;
        }

        int baseDamage = weapon.calcDamage();

        if (targetJet is BomberJet) {
            baseDamage += (baseDamage * 20) / 100;
        }
        targetJet.takeDamage(baseDamage);
    }

    public override void takeDamage(int baseDamage) {
        base.takeDamage(baseDamage);       
    }
}
