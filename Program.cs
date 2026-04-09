using airplanes.entities.Jets;
using airplanes.logic;
using airplanes.types;

Jet jet = new JetBuilder()
    .SetJetType(JetType.Fighter)
    .SetWeaponType(WeaponType.Canons)
    .SetAmmunitionType(AmmunitionType.Tracer)
    .SetArmorType(ArmorType.Cockpit)
    .Build();

Console.WriteLine(jet.ToString());
