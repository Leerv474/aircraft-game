using airplanes.entities.Jets;
using airplanes.logic;
using airplanes.types;

Warehouse warehouse = new (3);
var jet = warehouse.AssembleJet();

Console.WriteLine(jet.ToString());

