using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public Transform playerTransform;
    public Animator beamAnimator;

    public void BeamAttack()
    {
        beamAnimator.SetTrigger("ActivateAttack");
    }

    private void Target()
    {
        Vector2 direction = playerTransform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}
