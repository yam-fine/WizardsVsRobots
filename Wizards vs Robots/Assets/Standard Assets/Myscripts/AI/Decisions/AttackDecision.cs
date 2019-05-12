using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Attack")]
public class AttackDecision : Decision
{
    RaycastHit hit;
    [Tooltip("distance in which enemy will stop and attack his target")]
    [SerializeField] float attackDistance;

    public override bool Decide(StateController controller)
    {
        Vector3 myPos = controller.transform.position;
        Physics.Raycast(myPos,
                        controller.GetComponent<Enemy>().transform.forward,
                        out hit);

        return Vector3.Distance(myPos, hit.point) <= attackDistance;
    }
}
