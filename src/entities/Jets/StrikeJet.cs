namespace airplanes.entities.Jets;

public class StrikeJet : Jet
{
    private bool FirstHit = true;
    public StrikeJet() {
        this.Health = 480;
        this.EvasionChance = 10;
    }
    public override void Attack(Jet target)
    {
        base.Attack(target);
    }

    public override void TakeDamage(Int32 baseDamage)
    {
        if (FirstHit) {
            FirstHit = false;
            return;
        }
        base.TakeDamage(baseDamage);
    }
}
