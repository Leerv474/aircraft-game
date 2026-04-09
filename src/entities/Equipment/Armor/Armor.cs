namespace airplanes.entities.Equipment.Armor;

public abstract class Armor {
    protected int protectionValue {get; set;}
    public int getProtectionValue() {
        return protectionValue;
    }

    public override string ToString()
    {
        return $"Armor type: {this.GetType().Name}";
    }
}
