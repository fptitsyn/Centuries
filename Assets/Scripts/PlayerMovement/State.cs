using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{
    public abstract class State
    {
        public abstract void Enter();
        public abstract void Tick();
        public abstract void Exit();
    }
}
