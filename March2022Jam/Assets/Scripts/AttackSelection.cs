using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelection : MonoBehaviour
{
    public int battlePhase;
    public bool trackerOut;
    public bool orbitalsOut;
    public Animator bossAnim;
    // Start is called before the first frame update
    void Start()
    {
        trackerOut = false;
        orbitalsOut = false;
    }

    public void ChooseAttack()
    {
        int attackIndex = PickAttack();
        while ((orbitalsOut && attackIndex == 1) || (trackerOut && attackIndex == 4)){
            attackIndex = PickAttack();
        }
        bossAnim.SetTrigger("attack" + attackIndex);
        orbitalsOut = attackIndex == 1;
        trackerOut = attackIndex == 4;
        Debug.Log("attack ");
    }

    private int PickAttack()
    {
        switch (battlePhase)
        {
            case 1:
                return Random.Range(0, 3);
            case 2:
                return Random.Range(0, 4);
            case 3:
                return Random.Range(0, 5);
        }
        return 1;
    }
}
