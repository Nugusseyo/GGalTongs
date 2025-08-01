using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
   private WaitForSeconds WaitT = new WaitForSeconds(0.5f);
   [SerializeField] private RandomAttack _beamSO;
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.TryGetComponent<EnemyHP>(out EnemyHP enemy))
      {
         Attack(enemy);
      }
   }

   private IEnumerator Attack(EnemyHP enemy)
   { 
      enemy.TakeDamage(_beamSO.AtkDMG);
      yield return WaitT;
   }
}
