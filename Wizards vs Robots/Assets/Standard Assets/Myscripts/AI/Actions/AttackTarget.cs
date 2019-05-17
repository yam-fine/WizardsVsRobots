using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackTarget : Action
{
    public override void Act(StateController controller)
    {
        controller.enemy.Attack();
        Debug.Log("attacking target");
    }
}
