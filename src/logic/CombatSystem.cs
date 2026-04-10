namespace airplanes.logic;

using airplanes.entities.FiredShots;
using airplanes.entities.Jets;
using airplanes.entities.Teams;
using airplanes.types;

public class CombatSystem
{
    private List<FiredShot> FiredShots = new();

    // private Dictionary<Int32, Team> Teams = new();
    private Int32 LastTeamNumber = 1;

    // public void AddTeam(Team team) {
    //     this.Teams.Add(LastTeamNumber, team);
    //     LastTeamNumber++;
    // }
    //
    // public void SetTeamAttackTactic(Int32 teamNumber, AttackTactic tactic) {
    //     Teams[teamNumber].AttackTactic = tactic;
    // }

    private Team RedTeam = new();
    private Team BlueTeam = new();

    public void SetRedTeamAttackTactic(AttackTactic tactic)
    {
        RedTeam.AttackTactic = tactic;
    }

    public void SetBlueTeamAttackTactic(AttackTactic tactic)
    {
        BlueTeam.AttackTactic = tactic;
    }

    private void StrongestTargetAttack(Team attackingTeam, Team targetTeam)
    {
        var targetJets = targetTeam.GetJets();
        Jet targetJet = targetJets
            .Where(jet => jet.GetCurrentHealth() == targetJets.Max(jet => jet.GetCurrentHealth()))
            .First();
        this.FiredShots.AddRange(attackingTeam.Attack(targetJet));
    }

    private void CommanderAttack(Team attackingTeam, Jet targetJet)
    {
        if (attackingTeam.GetJets().Contains(targetJet))
        {
            throw new Exception("frienly fire");
        }

        attackingTeam.Attack(targetJet);
        this.FiredShots.AddRange(attackingTeam.Attack(targetJet));
    }

    private void WeakestTargetAttack(Team attackingTeam, Team targetTeam)
    {
        var targetJets = targetTeam.GetJets();
        Jet targetJet = targetJets
            .Where(jet => jet.GetCurrentHealth() == targetJets.Min(jet => jet.GetCurrentHealth()))
            .First();
        attackingTeam.Attack(targetJet);
    }

    private void RandomTargetAttack(Team attackingTeam, Team targetTeam) {
        var targetJets = targetTeam.GetJets();
        int randomId = Random.Shared.Next(targetJets.Count());
        Jet targetJet = targetJets[randomId];
        attackingTeam.Attack(targetJet);
    }

    private void PriorityAttack(Team attackingTeam, Team targetTeam) {
        attackingTeam.PriorityAttack(targetTeam);
    }
}
