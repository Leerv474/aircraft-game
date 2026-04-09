namespace airplanes.entities.Equipment.Ammunition;

using airplanes.entities.Jets;

public abstract class Ammunition
{
    protected int bonusDamage { get; set; }

    public int applyBonusDamage(int baseDamage)
    {
        return baseDamage + bonusDamage;
    }

    public abstract void applyDebuff(Jet jet);

    public override string ToString()
    {
        return $"Ammunition type: {this.GetType().Name}";
    }
}
