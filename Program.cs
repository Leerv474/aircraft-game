using airplanes.entities.Jets;
using airplanes.logic;
using airplanes.types;

Jet jet = new JetBuilder()
    .SetJetType(JetType.Fighter)
    .SetPrimaryWeaponType(WeaponType.Canons)
    .SetSecondaryWeaponType(WeaponType.Canons)
    .SetAmmunitionType(AmmunitionType.Tracer)
    .SetArmorType(ArmorType.Cockpit)
    .Build();

Console.WriteLine(jet.ToString());

Jet jet2 = new JetBuilder()
    .SetJetType(JetType.Bomber)
    .SetPrimaryWeaponType(WeaponType.Canons)
    .SetSecondaryWeaponType(WeaponType.Canons)
    .SetAmmunitionType(AmmunitionType.Tracer)
    .SetArmorType(ArmorType.Cockpit)
    .Build();

Console.WriteLine(jet.ToString());
Console.WriteLine(jet2.ToString());

jet.Attack(jet2);


Console.WriteLine(jet.ToString());
Console.WriteLine(jet2.ToString());
