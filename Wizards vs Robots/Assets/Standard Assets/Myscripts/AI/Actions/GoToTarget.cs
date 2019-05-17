using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/GoToTarget")]
public class GoToTarget : Action
{
    public override void Act(StateController controller)
    {
        controller.enemy.Move();
        Debug.Log("Walking towards " + controller.enemy.Target);
    }
}
