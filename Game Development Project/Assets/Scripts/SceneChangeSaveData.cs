using Assets.Scripts.Npc;
using UnityEngine;

namespace Assets.Scripts
{
    public static class SceneChangeSaveData
    {
        public static Vector3? MainCharacterPosition { get; set; }
        public static Quaternion? MainCharacterRotation { get; set; }
        public static NpcType InteractedNpcType { get; set; }
        public static Vector3? NpcPosition { get; set; }
    }
}
