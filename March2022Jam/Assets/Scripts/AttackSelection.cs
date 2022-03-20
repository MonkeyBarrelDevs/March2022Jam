using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelection : MonoBehaviour
{
    [SerializeField] private int battlePhase;
    public bool trackerOut;
    public bool orbitalsOut;
    // Start is called before the first frame update
    void Start()
    {
        trackerOut = false;
        orbitalsOut = false;
    }

    private void Update()
    {
        
    }

    public int ChooseAttack()
    {
        int attackIndex = PickAttack();
        while (orbitalsOut && attackIndex == 1){
            attackIndex = PickAttack();
        }
        if (attackIndex == 1)
            orbitalsOut = true;
        Debug.Log("Attack " + attackIndex.ToString());
        return attackIndex;
    }

    private int PickAttack()
    {
        Debug.Log(battlePhase);
        switch (battlePhase)
        {
            case 1:
                return Random.Range(0, 3);
            case 2:
                return Random.Range(0, 4);
            case 3:
                return Random.Range(0, 5);
        }
        return -1;
    }
}
