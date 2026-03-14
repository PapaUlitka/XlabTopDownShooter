using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Magic.Buffs.Extensions
{
    public static class BuffExtensions
    {
        public static void Refresh(this IBuff buff, BuffContainer buffContainer)
        {
            buff.Deinitialize();
            buff.Initialize(buffContainer);
        }
    }
}
