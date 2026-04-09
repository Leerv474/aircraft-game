using airplanes.entities.Jets;

namespace airplanes.entities.Equipment.Ammunition;

public class HeapRounds: Ammunition {
    public HeapRounds() {
        this.BonusDamage = 18;
    }

    public override void ApplyDebuff(Jet jet)
    {
        jet.TurnSkip = true;
    }
}
