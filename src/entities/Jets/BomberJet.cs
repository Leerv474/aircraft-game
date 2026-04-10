using airplanes.types;

namespace airplanes.entities.Jets;

public class BomberJet : Jet
{
    public BomberJet()
    {
        this.Health = 680;
        this.EvasionChance = 5;
        this.Type = JetType.Bomber;
    }

    public void ArealStrike()
    {
        if (ArmorPierced) {
            return;
        }
        throw new NotImplementedException();
    }
}
