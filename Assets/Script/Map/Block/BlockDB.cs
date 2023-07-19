using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Minefarm.Map.Block
{
    public static class BlockDB
    {
        private const string BLOCK_PATH = "Entity/Block";

        private static Dictionary<BlockID, GameObject> db_block= new();
        private static Dictionary<BlockID, Material> db_material= new();
        private static Dictionary<BlockID, Material> db_pixelizedMaterial = new();
        static BlockDB()
        {
            Initialize();
        }
        
        private static void Initialize()
        {

        }

        private static string GetBlockFileName(BlockID id)
            => $"[{(int)id}]{id}";
        private static string GetBlockPath(BlockID id)
            => $"{BLOCK_PATH}/{GetBlockFileName(id)}/{GetBlockFileName(id)}";
        private static string GetMaterialPath(BlockID id)
            => $"{BLOCK_PATH}/{GetBlockFileName(id)}/{id}";
        private static string GetPixelizedMaterialPath(BlockID id)
            => $"{BLOCK_PATH}/{GetBlockFileName(id)}/{id} (Pixelized)";
        public static GameObject Load(BlockID id)
        {
            if (!db_block.ContainsKey(id))
                db_block.Add(id, Resources.Load(GetBlockPath(id)) as GameObject);
            return db_block[id];
        }

        public static bool IsBreak(BlockID id)
        {
            return true;
        }
    }
}
