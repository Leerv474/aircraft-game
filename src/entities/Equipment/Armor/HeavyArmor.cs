namespace airplanes.entities.Equipment.Armor;

class HeavyArmor : Armor {
    public const Int32 EvasionPenalty = 10;
    public HeavyArmor() {
        this.ProtectionValue = 25;
    }
}
