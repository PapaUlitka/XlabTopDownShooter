using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Entities
{
    public interface IAcceleration
    {
        public void IncreaseAcceleration(float delta);

        public void DecreaseAcceleration(float delta);
    }
}
