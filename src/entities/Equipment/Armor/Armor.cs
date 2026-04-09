namespace airplanes.entities.Equipment.Armor;

public abstract class Armor
{
    protected Int32 ProtectionValue { get; set; }

    public Int32 GetProtectionValue()
    {
        return ProtectionValue;
    }

    public override string ToString()
    {
        return $"Armor type: {this.GetType().Name}";
    }
}
