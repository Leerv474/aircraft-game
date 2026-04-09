namespace airplanes.entities.Equipment.Ammunition;

using airplanes.entities.Jets;

public class TracerRounds : Ammunition
{
    public TracerRounds() {
        this.bonusDamage = 12;
    }

    public override void applyDebuff(Jet jet)
    {
        jet.marked = true;
    }
}
