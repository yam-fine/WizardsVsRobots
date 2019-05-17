using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackTarget : Action
{
    public override void Act(StateController controller)
    {
        Enemy myself = controller.GetComponent<Enemy>();
        if (myself.CanAttack)
            myself.Attack();
        Debug.Log("attacking target");
    }
}
