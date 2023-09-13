using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.MapLoader
{
    [CreateAssetMenu(fileName = "MapModel", menuName = "NekoBrawler/Mapmodel")]
    public class MapModel : ScriptableObject
    {
        public string MapID;
        public string MapName;
        public string SceneName;
    }

}
