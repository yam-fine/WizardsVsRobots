using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/RayAttack")]
public class RayAttackDecision : Decision
{
    RaycastHit hit;
    [Tooltip("distance in which enemy will stop and attack his target")]
    [SerializeField] float attackDistance;

    public override bool Decide(StateController controller)
    {
        if (controller.CheckIfCountDownElapsed(controller.enemy.AttackSpeed))
            return InRange(controller);
        return false;
    }

    bool InRange(StateController controller)
    {
        Vector3 myPos = controller.transform.position;
        Physics.Raycast(myPos,
                        controller.transform.forward,
                        out hit);
        //Debug.DrawRay(myPos, controller.transform.forward, Color.red);
        return Vector3.Distance(myPos, hit.point) <= attackDistance;
    }
}
