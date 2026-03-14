using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Infrastructure.States
{
    public interface IState
    {
        public void Enter();

        public void Update() { }

        public void Exit();
    }
}
