using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Minefarm.Entity.Actor.Block
{
    public static class BlockDB
    {
        private const string PATH_BLOCK = "Entity/Block";


        private static Dictionary<BlockID, GameObject> db_block = new();
        private static Dictionary<int, Material> db_invisible_material = new();
        static BlockDB()
        {
            Initialize();
        }

        private static void Initialize()
        {

        }

        private static string GetBlockPath(BlockID id)
            => $"{PATH_BLOCK}/{id}";
        private static string GetMaterialPath()
            => $"{PATH_BLOCK}/Material";
        public static GameObject LoadBlock(BlockID id)
        {
            if (!db_block.ContainsKey(id))
                db_block.Add(id, Resources.Load(GetBlockPath(id)) as GameObject);
            if (db_block[id] == null)
                db_block[id] = Resources.Load(GetBlockPath(id)) as GameObject;
            return db_block[id];
        }

        public static Material LoadInvisibleMaterial(int level)
        {
            if (level > 5) level = 5;
            if (!db_invisible_material.ContainsKey(level))
                db_invisible_material.Add(level, 
                    Resources.Load($"{GetMaterialPath()}/Block.{level}") as Material);
            if (db_invisible_material[level] == null)
                db_invisible_material[level] = Resources.Load($"{GetMaterialPath()}/Block.{level}") as Material;
            return db_invisible_material[level];
        }

        public static bool IsBreak(BlockID id)
        {
            return true;
        }
    }
}
