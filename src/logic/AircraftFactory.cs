namespace airplanes.logic;

using airplanes.entities.Equipment.Ammunition;
using airplanes.entities.Equipment.Armor;
using airplanes.entities.Equipment.Weapons;
using airplanes.entities.Jets;
using airplanes.types;

public static class AircraftFactory
{
    private static readonly Dictionary<JetType, Func<Jet>> JetRegistry = new()
    {
        { JetType.Fighter, () => new FighterJet() },
        { JetType.Strike, () => new StrikeJet() },
        { JetType.Bomber, () => new BomberJet() },
    };
    private static readonly Dictionary<WeaponType, Func<Weapon>> WeaponRegistry = new()
    {
        { WeaponType.Canons, () => new Canons() },
        { WeaponType.Miniguns, () => new Miniguns() },
        { WeaponType.RocketLaunchers, () => new RocketLaunchers() },
    };
    private static readonly Dictionary<ArmorType, Func<Armor>> ArmorRegistry = new()
    {
        { ArmorType.Cockpit, () => new ArmoredCockpit() },
        { ArmorType.FuelTank, () => new ArmoredFuelTank() },
        { ArmorType.Heavy, () => new HeavyArmor() },
    };
    private static readonly Dictionary<AmmunitionType, Func<Ammunition>> AmmunitionRegistry = new()
    {
        { AmmunitionType.ArmorPiercing, () => new ArmorPiercingRounds() },
        { AmmunitionType.Heap, () => new HeapRounds() },
        { AmmunitionType.Tracer, () => new TracerRounds() },
    };

    public static Jet CreateJet(JetType type)
    {
        if (!JetRegistry.TryGetValue(type, out var creator))
        {
            throw new ArgumentException("unknown jet type");
        }
        return creator();
    }

    public static Weapon CreateWeapon(WeaponType type)
    {
        if (!WeaponRegistry.TryGetValue(type, out var creator))
        {
            throw new ArgumentException("unknown jet type");
        }
        return creator();
    }

    public static Armor CreateArmor(ArmorType type)
    {
        if (!ArmorRegistry.TryGetValue(type, out var creator))
        {
            throw new ArgumentException("unknown jet type");
        }
        return creator();
    }

    public static Ammunition CreateAmmunition(AmmunitionType type)
    {
        if (!AmmunitionRegistry.TryGetValue(type, out var creator))
        {
            throw new ArgumentException("unknown jet type");
        }
        return creator();
    }
}
