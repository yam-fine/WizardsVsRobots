using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/BetweenAttacks")]
public class BetweenAttacks : Action
{
    public override void Act(StateController controller)
    {
        controller.enemy.BetweenAttacks();
        Debug.Log("waiting to attack");
    }
}