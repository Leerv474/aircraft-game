namespace airplanes.entities.Equipment.Armor;

class HeavyArmor : Armor {
    public const int evasionPenalty = 10;
    public HeavyArmor() {
        this.protectionValue = 25;
    }
}
