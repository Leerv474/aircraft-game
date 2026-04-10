namespace airplanes.entities.Equipment.Armor;
using airplanes.entities.Equipment.Ammunition;

class HeavyArmor : Armor {
    public HeavyArmor() {
        this.ProtectionValue = 25;
        this.EvasionPenalty = 10;
    }
    public override Int32 ReduceDamage(Int32 baseDamage, Ammunition ammunitionAbsorbed) {

        int damageReduction = this.ProtectionValue;
        if (ammunitionAbsorbed is HeapRounds) {
            damageReduction += 50;
        }

        int damage = baseDamage - (baseDamage * damageReduction) / 100;
        return damage;
    }
}
