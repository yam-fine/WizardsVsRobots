using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackTarget : Action
{
    public override void Act(StateController controller)
    {
        Debug.Log("attacking target");
    }
}
