namespace airplanes.entities.Equipment.Armor;
using airplanes.entities.Equipment.Ammunition;

public abstract class Armor
{
    protected Int32 ProtectionValue { get; set; }
    protected Int32 EvasionPenalty { get; set; } = 0;

    public virtual Int32 ReduceDamage(Int32 baseDamage, Ammunition ammunitionAbsorbed) {
        int damageReduction = this.ProtectionValue;

        int damage = baseDamage - (baseDamage * damageReduction) / 100;
        return damage;
    }

    public override string ToString()
    {
        return $"Armor type: {this.GetType().Name}";
    }

    internal Int32 GetEvasionPenalty()
    {
        return this.EvasionPenalty;
    }
}
