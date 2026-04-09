namespace airplanes.entities.Jets;

public class StrikeJet : Jet
{
    private bool firstHit = true;
    public StrikeJet() {
        this.health = 480;
        this.evasionChance = 10;
    }
    public override void attack(Jet target)
    {
        base.attack(target);
    }

    public override void takeDamage(int baseDamage)
    {
        if (firstHit) {
            firstHit = false;
            return;
        }
        base.takeDamage(baseDamage);
    }
}
