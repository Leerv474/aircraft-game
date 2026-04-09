namespace airplanes.logic;

using airplanes.entities.Equipment.Ammunition;
using airplanes.entities.Equipment.Armor;
using airplanes.entities.Equipment.Weapons;
using airplanes.entities.Jets;
using airplanes.types;

public static class AircraftFactory
{
    private static readonly Dictionary<JetType, Func<Jet>> jetRegistry = new()
    {
        { JetType.FIGHTER, () => new FighterJet() },
        { JetType.STRIKE, () => new StrikeJet() },
        { JetType.BOMBER, () => new BomberJet() },
    };
    private static readonly Dictionary<WeaponType, Func<Weapon>> weaponRegistry = new()
    {
        { WeaponType.CANONS, () => new Canons() },
        { WeaponType.MINIGUNS, () => new Miniguns() },
        { WeaponType.ROCKETGUNS, () => new RocketGun() },
    };
    private static readonly Dictionary<ArmorType, Func<Armor>> armorRegistry = new()
    {
        { ArmorType.COCKPIT, () => new ArmoredCockpit() },
        { ArmorType.FUEL_TANK, () => new ArmoredFuelTank() },
        { ArmorType.HEAVY, () => new HeavyArmor() },
    };
    private static readonly Dictionary<AmmunitionType, Func<Ammunition>> ammunitionRegistry = new()
    {
        { AmmunitionType.ARMOR_PIERCING, () => new ArmorPiercingRounds() },
        { AmmunitionType.HEAP, () => new HeapRounds() },
        { AmmunitionType.TRACER, () => new TracerRounds() },
    };

    public static Jet createJet(JetType type)
    {
        if (!jetRegistry.TryGetValue(type, out var creator))
        {
            throw new ArgumentException("unknown jet type");
        }
        return creator();
    }

    public static Weapon createWeapon(WeaponType type)
    {
        if (!weaponRegistry.TryGetValue(type, out var creator))
        {
            throw new ArgumentException("unknown jet type");
        }
        return creator();
    }

    public static Armor createArmor(ArmorType type)
    {
        if (!armorRegistry.TryGetValue(type, out var creator))
        {
            throw new ArgumentException("unknown jet type");
        }
        return creator();
    }

    public static Ammunition createAmmunition(AmmunitionType type)
    {
        if (!ammunitionRegistry.TryGetValue(type, out var creator))
        {
            throw new ArgumentException("unknown jet type");
        }
        return creator();
    }
}
