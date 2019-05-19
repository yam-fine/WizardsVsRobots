using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Can Attack")]
public class CanAttackDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return controller.enemy.CanAttack;
    }
}