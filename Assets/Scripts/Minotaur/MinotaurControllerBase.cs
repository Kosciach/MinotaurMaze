using MinotaurStateMachineSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinotaurControllers
{
    public class MinotaurControllerBase : MonoBehaviour
    {
        protected MinotaurStateMachine _minotaurStateMachine;


        protected void OnAwake()
        {
            _minotaurStateMachine = transform.root.GetComponent<MinotaurStateMachine>();
        }
    }
}