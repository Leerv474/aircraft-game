using airplanes.entities.Jets;
using airplanes.logic;
using airplanes.types;

Jet jet = new JetBuilder()
    .setJetType(JetType.FIGHTER)
    .setWeaponType(WeaponType.CANONS)
    .setAmmunitionType(AmmunitionType.TRACER)
    .setArmorType(ArmorType.COCKPIT)
    .build();

Console.WriteLine(jet.ToString());
