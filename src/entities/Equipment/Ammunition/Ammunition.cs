namespace airplanes.entities.Equipment.Ammunition;

using airplanes.entities.Jets;

public abstract class Ammunition
{
    protected Int32 BonusDamage { get; set; }

    public Int32 GetBonusDamage()
    {
        return BonusDamage;
    }

    public abstract void ApplyDebuff(Jet jet);

    public override string ToString()
    {
        return $"Ammunition type: {this.GetType().Name}";
    }
}
