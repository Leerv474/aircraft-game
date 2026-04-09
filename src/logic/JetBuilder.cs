namespace airplanes.logic;

using airplanes.entities.Jets;
using airplanes.types;

public class JetBuilder
{

    private JetType JetType { get; set; }
    private WeaponType WeaponType { get; set; }
    private ArmorType ArmorType { get; set; }
    private AmmunitionType AmmunitionType { get; set; }

    public JetBuilder SetJetType(JetType type)
    {
        this.JetType = type;
        return this;
    }

    public JetBuilder SetWeaponType(WeaponType type)
    {
        bool incompatibleAmmo = this.AmmunitionType == AmmunitionType.None && type == WeaponType.RocketLaunchers && this.AmmunitionType == AmmunitionType.Tracer;
        if (incompatibleAmmo) {
            throw new Exception("tracer rounds canno be used with rocket guns");
        }
        this.WeaponType = type;
        return this;
    }

    public JetBuilder SetArmorType(ArmorType type)
    {
        this.ArmorType = type;
        return this;
    }

    public JetBuilder SetAmmunitionType(AmmunitionType type)
    {
        bool incompatibleAmmo = this.WeaponType != WeaponType.None && this.WeaponType == WeaponType.RocketLaunchers && type == AmmunitionType.Tracer;
        if (incompatibleAmmo) {
            throw new Exception("tracer rounds canno be used with rocket guns");
        }
        this.AmmunitionType = type;
        return this;
    }

    public Jet Build() {
        bool propertiesMissing = this.JetType == JetType.None|| this.WeaponType == WeaponType.None|| this.AmmunitionType == AmmunitionType.None|| this.ArmorType == ArmorType.None;
        if (propertiesMissing) {
            throw new Exception("properties missing");
        }
        Jet jet = AircraftFactory.CreateJet(this.JetType);
        jet.SetWeapon(AircraftFactory.CreateWeapon(this.WeaponType));
        jet.SetArmor(AircraftFactory.CreateArmor(this.ArmorType));
        jet.SetAmmunition(AircraftFactory.CreateAmmunition(this.AmmunitionType));
        return jet;
    }
}
