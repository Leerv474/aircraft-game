using airplanes.entities.FiredShots;
using airplanes.entities.Jets;
using airplanes.types;

namespace airplanes.entities.Teams;

public class Team
{
    private List<Jet> Jets = new();
    public AttackTactic AttackTactic = AttackTactic.RandomTarget;

    public void AddJet(Jet jet)
    {
        this.Jets.Add(jet);
    }

    public List<Jet> GetJets()
    {
        return Jets;
    }

    public List<FiredShot> Attack(Jet targetJet)
    {
        List<FiredShot> firedShots = new();
        if (targetJet.IsDead())
        {
            return firedShots;
        }
        foreach (Jet jet in Jets)
        {
            if (jet.IsDead())
            {
                continue;
            }
            firedShots.AddRange(jet.Attack(targetJet));
        }
        return firedShots;
    }

    // Истребитель -> бомбардировщик
    // Штурмовик -> истребитель
    // Бомбардировщик -> случайная цель
    internal List<FiredShot> PriorityAttack(Team targetTeam)
    {
        List<FiredShot> shots = new();
        List<Jet> friendlyFighterJets = this
            .Jets.Where(jet => jet is FighterJet && !jet.IsDead())
            .ToList();
        List<Jet> friendlyStrikeJets = this
            .Jets.Where(jet => jet is StrikeJet && !jet.IsDead())
            .ToList();
        List<Jet> friendlyBomberJets = this
            .Jets.Where(jet => jet is BomberJet && !jet.IsDead())
            .ToList();

        Jet enemyFighterJet = targetTeam.Jets.Where(jet => jet is FighterJet).First();
        Jet enemyBomberJet = targetTeam.Jets.Where(jet => jet is BomberJet).First();

        foreach (Jet jet in friendlyFighterJets)
        {
            shots.AddRange(jet.Attack(enemyBomberJet));
        }
        foreach (Jet jet in friendlyStrikeJets)
        {
            shots.AddRange(jet.Attack(enemyFighterJet));
        }
        foreach (Jet jet in friendlyBomberJets)
        {
            var targetJets = targetTeam.GetJets();
            int randomId = Random.Shared.Next(targetJets.Count());
            Jet targetJet = targetJets[randomId];
            shots.AddRange(jet.Attack(targetJet));
        }
        return shots;
    }
}
