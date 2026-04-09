namespace airplanes.entities.Jets;

public class BomberJet : Jet
{
    public BomberJet()
    {
        this.health = 680;
        this.evasionChance = 5;
    }

    public override void attack(Jet target)
    {
        base.attack(target);
    }

    public override void takeDamage(int baseDamage)
    {
        base.takeDamage(baseDamage);
    }

    public void arealStrike()
    {
        if (armorPierced) {
            return;
        }
        throw new NotImplementedException();
    }
}
