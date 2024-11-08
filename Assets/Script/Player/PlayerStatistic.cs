using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistic : MonoBehaviour
{
    [SerializeField] private Player player;
    public float currentAttack;
    public float currentDefense;

    private void Start()
    {
        player = GetComponent<Player>();

        currentAttack = player.playerStat.baseAttack;
    }

    public void AttackPlusUpdate(float bonusAttack)
    {       
        currentAttack += bonusAttack;
        Debug.Log("Increase Attack");
    }
}
