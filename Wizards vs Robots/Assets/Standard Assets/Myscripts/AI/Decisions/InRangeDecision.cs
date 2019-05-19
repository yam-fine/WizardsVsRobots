using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/In Range")]
public class InRangeDecision : Decision
{
    [SerializeField] bool attackPlayer = true;
    [SerializeField] bool attackBase = true;

    public override bool Decide(StateController controller)
    {
        return InRange(controller);
    }

    bool InRange(StateController controller)
    {
        List<GameObject> targets = controller.enemy.Sight.InSight;

        if (targets.Count > 0)
        {
            foreach (GameObject target in targets)
            {
                if (attackPlayer && target.tag == "Player")
                    return true;
                if (attackBase && target.tag == "Base")
                    return true;
            }
        }

        return false;
    }
}