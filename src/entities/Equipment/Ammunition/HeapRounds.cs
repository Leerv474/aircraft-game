using airplanes.entities.Jets;

namespace airplanes.entities.Equipment.Ammunition;

public class HeapRounds: Ammunition {
    public HeapRounds() {
        this.bonusDamage = 18;
    }

    public override void applyDebuff(Jet jet)
    {
        jet.turnSkip = true;
    }
}
