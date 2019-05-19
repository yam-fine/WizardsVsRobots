using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/RayAttack")]
public class RayAttackDecision : Decision
{
    RaycastHit hit;
    [Tooltip("distance in which enemy will stop and attack his target")]
    [SerializeField] float attackDistance;
    [SerializeField] bool attackPlayer = true;
    [SerializeField] bool attackBase = true;

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
                        out hit,
                        attackDistance, 9);
        //Debug.DrawRay(myPos, controller.transform.forward, Color.red);
        Debug.Log(hit.transform.name);

        if (hit.collider.gameObject.tag == "Player" && attackPlayer)
            return true;
        if (hit.collider.gameObject.tag == "Base" && attackBase)
            return true;
        return false;
    }
}
