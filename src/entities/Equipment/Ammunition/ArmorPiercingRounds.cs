using airplanes.entities.Jets;

namespace airplanes.entities.Equipment.Ammunition;

public class ArmorPiercingRounds : Ammunition
{
    public ArmorPiercingRounds()
    {
        this.bonusDamage = 10;
    }

    public override void applyDebuff(Jet jet)
    {
        jet.armorPierced = true;
    }
}
