namespace airplanes.entities.Equipment.Ammunition;

using airplanes.entities.Jets;

public abstract class Ammunition
{
    protected Int32 BonusDamage { get; set; }

    public Int32 ApplyBonusDamage(Int32 baseDamage)
    {
        return baseDamage + BonusDamage;
    }

    public abstract void ApplyDebuff(Jet jet);

    public override string ToString()
    {
        return $"Ammunition type: {this.GetType().Name}";
    }
}
