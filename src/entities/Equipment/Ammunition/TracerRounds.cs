namespace airplanes.entities.Equipment.Ammunition;

using airplanes.entities.Jets;

public class TracerRounds : Ammunition
{
    public TracerRounds() {
        this.BonusDamage = 12;
    }

    public override void ApplyDebuff(Jet jet)
    {
        jet.Marked = true;
    }
}
