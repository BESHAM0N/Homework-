using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
   [SerializeField] private Character _character;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         //_character.Shoot;
      }
   }
}
