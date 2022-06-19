using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
   [SerializeField] private float _timeInvulnerability;
   [HideInInspector ]public bool invulnerability;
   private Color _color;
   private Color _colorInst;
   

   private void Start()
   { 
       _colorInst = GetComponent<Renderer>().material.color;
   }

   public void Hit()
   {
       invulnerability = true;
      StartCoroutine(Invul());
   }

   IEnumerator Invul()
   {
       GetComponent<Renderer>().material.color = Color.black;
       yield return new WaitForSeconds(_timeInvulnerability);
       GetComponent<Renderer>().material.color = _colorInst;
       invulnerability = false;
   }
}
