using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public Transform playerTransform;
    public bool triggerBeam = false;
    public bool triggerOrbitals = false;
    public Animator bossAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (triggerBeam == true)
        {
            BeamAttack();
            triggerBeam = false;
        }
        if (triggerOrbitals == true)
        {
            bossAnimator.SetTrigger("BeamAttackActivate");
            triggerOrbitals = false;
        }
    }

    public void BeamAttack()
    {
        Target();
        bossAnimator.SetTrigger("BeamAttackActivate");
    }

    private void Target()
    {
        Vector2 direction = playerTransform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}
