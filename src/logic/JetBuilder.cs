namespace airplanes.logic;

using airplanes.entities.Jets;
using airplanes.types;

public class JetBuilder
{

    private JetType jetType { get; set; }
    private WeaponType weaponType { get; set; }
    private ArmorType armorType { get; set; }
    private AmmunitionType ammunitionType { get; set; }

    public JetBuilder setJetType(JetType type)
    {
        this.jetType = type;
        return this;
    }

    public JetBuilder setWeaponType(WeaponType type)
    {
        bool incompatibleAmmo = this.ammunitionType == AmmunitionType.NONE && type == WeaponType.ROCKETGUNS && this.ammunitionType == AmmunitionType.TRACER;
        if (incompatibleAmmo) {
            throw new Exception("tracer rounds canno be used with rocket guns");
        }
        this.weaponType = type;
        return this;
    }

    public JetBuilder setArmorType(ArmorType type)
    {
        this.armorType = type;
        return this;
    }

    public JetBuilder setAmmunitionType(AmmunitionType type)
    {
        bool incompatibleAmmo = this.weaponType != WeaponType.NONE && this.weaponType == WeaponType.ROCKETGUNS && type == AmmunitionType.TRACER;
        if (incompatibleAmmo) {
            throw new Exception("tracer rounds canno be used with rocket guns");
        }
        this.ammunitionType = type;
        return this;
    }

    public Jet build() {
        bool propertiesMissing = this.jetType == JetType.NONE|| this.weaponType == WeaponType.NONE|| this.ammunitionType == AmmunitionType.NONE|| this.armorType == ArmorType.NONE;
        if (propertiesMissing) {
            throw new Exception("properties missing");
        }
        Jet jet = AircraftFactory.createJet(this.jetType);
        jet.setWeapon(AircraftFactory.createWeapon(this.weaponType));
        jet.setArmor(AircraftFactory.createArmor(this.armorType));
        jet.setAmmunition(AircraftFactory.createAmmunition(this.ammunitionType));
        return jet;
    }
}
