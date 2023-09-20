using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinotaurControllers
{
    public class MinotaurFlipController : MinotaurControllerBase
    {
        private Vector3 _previousPosition;


        private void Awake()
        {
            OnAwake();
        }



        public void CheckFlip()
        {
            Vector3 currentPosition = transform.root.position;

            int xScale = (int)transform.localScale.x;
            if (currentPosition.x > _previousPosition.x) xScale = 4;
            else if (currentPosition.x < _previousPosition.x) xScale = -4;
            transform.localScale = new Vector3(xScale, 4, 4);

            _previousPosition = currentPosition;
        }
    }
}