using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/GoToBase")]
public class GoToBase : Action
{
    public override void Act(StateController controller)
    {
        WalkTo(controller);
        Debug.Log(controller.name + " Walking towards player base");
    }

    void WalkTo(StateController controller)
    {
        Enemy myself = controller.GetComponent<Enemy>();
        GameObject playerBase = GameObject.FindGameObjectWithTag("Base");
        myself.Target = playerBase;
    }
}
