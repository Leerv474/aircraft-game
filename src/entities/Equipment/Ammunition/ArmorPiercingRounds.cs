using airplanes.entities.Jets;

namespace airplanes.entities.Equipment.Ammunition;

public class ArmorPiercingRounds : Ammunition
{
    public ArmorPiercingRounds()
    {
        this.BonusDamage = 10;
    }

    public override void ApplyDebuff(Jet jet)
    {
        jet.ArmorPierced = true;
    }
}
