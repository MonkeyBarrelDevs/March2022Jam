using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamageHandler : MonoBehaviour
{
    [SerializeField] GameContoller gameController;
    private void Start()
    {
        gameController = FindObjectOfType<GameContoller>();
    }

    private void OnTrigger2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            gameController.SubtractHP(1);
    }
}
