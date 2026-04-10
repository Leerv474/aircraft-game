namespace airplanes.logic;

using airplanes.entities.Jets;
using airplanes.types;

public class Warehouse
{
    private Dictionary<WeaponType, Int32> WeaponList;
    private Dictionary<ArmorType, Int32> ArmorList;
    private Dictionary<AmmunitionType, Int32> AmmunitionList;
    private Dictionary<Int32, JetType> JetTypeIdMap = new()
    {
        { 1, JetType.Fighter },
        { 2, JetType.Strike },
        { 3, JetType.Bomber },
    };
    private Dictionary<Int32, WeaponType> WeaponTypeIdMap = new()
    {
        { 1, WeaponType.Miniguns },
        { 2, WeaponType.Canons },
        { 3, WeaponType.RocketLaunchers },
    };
    private Dictionary<Int32, ArmorType> ArmorTypeIdMap = new()
    {
        { 1, ArmorType.Cockpit },
        { 2, ArmorType.FuelTank },
        { 3, ArmorType.Heavy },
    };
    private Dictionary<Int32, AmmunitionType> AmmunitionTypeIdMap = new()
    {
        { 1, AmmunitionType.Tracer },
        { 2, AmmunitionType.ArmorPiercing },
        { 3, AmmunitionType.Heap },
    };

    public Warehouse(Int32 numberOfJets)
    {
        int amountOfWeaponType = (int)Math.Ceiling((double)numberOfJets / 3);
        this.WeaponList = new()
        {
            { WeaponType.Canons, amountOfWeaponType },
            { WeaponType.Miniguns, amountOfWeaponType },
            { WeaponType.RocketLaunchers, amountOfWeaponType },
        };
        this.ArmorList = new()
        {
            { ArmorType.Cockpit, amountOfWeaponType },
            { ArmorType.FuelTank, amountOfWeaponType },
            { ArmorType.Heavy, amountOfWeaponType },
        };
        this.AmmunitionList = new()
        {
            { AmmunitionType.ArmorPiercing, amountOfWeaponType },
            { AmmunitionType.Heap, amountOfWeaponType },
            { AmmunitionType.Tracer, amountOfWeaponType },
        };
    }

    public Jet AssembleJet() {
        Console.WriteLine("---Jet assembly---");
        var jetType = ChooseJetType();
        var primaryWeaponType = ChoosePrimaryWeaponType();
        var secondaryWeaponType = ChooseSecondaryWeaponType();
        var armorType = ChooseArmorType();
        var ammunitionType = ChooseAmmunitionType();

        return new JetBuilder()
            .SetJetType(jetType)
            .SetPrimaryWeaponType(primaryWeaponType)
            .SetSecondaryWeaponType(secondaryWeaponType)
            .SetArmorType(armorType)
            .SetAmmunitionType(ammunitionType)
            .Build();
    }

    private JetType ChooseJetType()
    {
        int choice = 0;
        Console.WriteLine(
            """
            Jet types:
            1) Fighter jet
            2) Strike Jet
            3) Bomber Jet
            """
        );
        Console.Write("Choose type: ");
        choice = Console.Read();
        JetTypeIdMap.TryGetValue(choice, out var chosenType);
        return chosenType;
    }

    private WeaponType ChoosePrimaryWeaponType()
    {
        int choice = 0;
        Console.WriteLine(
            """
            Weapon types:
            1) Miniguns
            2) Canons
            3) RocketLaunchers
            """
        );
        Console.Write("Choose type: ");
        choice = Console.Read();
        WeaponTypeIdMap.TryGetValue(choice, out var chosenType);
        return chosenType;
    }
    private WeaponType ChooseSecondaryWeaponType()
    {
        int choice = 0;
        Console.WriteLine(
            """
            Weapon types:
            1) Miniguns
            2) Canons
            3) RocketLaunchers
            """
        );
        Console.Write("Choose type: ");
        choice = Console.Read();
        WeaponTypeIdMap.TryGetValue(choice, out var chosenType);
        return chosenType;
    }
    private ArmorType ChooseArmorType()
    {
        int choice = 0;
        Console.WriteLine(
            """
            Armor types:
            1) Cockpit armor
            2) Fuel tank armor
            3) Heavy armor
            """
        );
        Console.Write("Choose type: ");
        choice = Console.Read();
        ArmorTypeIdMap.TryGetValue(choice, out var chosenType);
        return chosenType;
    }
    private AmmunitionType ChooseAmmunitionType()
    {
        int choice = 0;
        Console.WriteLine(
            """
            Ammunition types:
            1) Tracer rounds
            2) Armor piercing rounds
            3) HEAP rounds
            """
        );
        Console.Write("Choose type: ");
        choice = Console.Read();
        AmmunitionTypeIdMap.TryGetValue(choice, out var chosenType);
        return chosenType;
    }

}
