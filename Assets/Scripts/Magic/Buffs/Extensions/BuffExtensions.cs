using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Buffs.Extensions
{
    public static class BuffExtensions
    {
        public static void Refresh(this IBuff buff, BuffContainer buffContainer)
        {
            buff.DeInitialize();
            buff.Initialize(buffContainer);
        }
    }
}