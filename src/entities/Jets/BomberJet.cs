using airplanes.types;

namespace airplanes.entities.Jets;

public class BomberJet : Jet
{
    public BomberJet()
    {
        this.Health = 680;
        this.EvasionChance = 5;
        this.Type = JetType.Bomber;
    }

    public override void Attack(Jet target)
    {
        base.Attack(target);
    }

    public override void TakeDamage(int baseDamage)
    {
        base.TakeDamage(baseDamage);
    }

    public void ArealStrike()
    {
        if (ArmorPierced) {
            return;
        }
        throw new NotImplementedException();
    }
}
