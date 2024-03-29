using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAttackingStateData", menuName = "Data/State Data/Attacking State")]
public class D_AttackingState : ScriptableObject
{
   public float sanityDamage = 1f;
   public float attackingTime = 1f;
}
