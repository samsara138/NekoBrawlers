using Core.Pattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem.MapLoader
{
    public class MapLoader : Singleton<MapLoader>
    {
        [SerializeField]
        private List<MapModel> maps = new List<MapModel>();

        public void LoadMap(string mapID)
        {
            var model = maps.Find(x => x.MapID == mapID);
            if(model != null)
            {
                SceneManager.LoadScene(model.SceneName);
            }
            else
            {
                Debug.LogError($"Map ID {mapID} not found");
            }
        }

        void CheckLoadedScenes()
        {
            // Get all loaded scenes.
            List<Scene> loadedScenes = new List<Scene>();
            int sceneCount = SceneManager.sceneCount;
            for (int i = 0; i < sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.isLoaded)
                {
                    loadedScenes.Add(scene);
                }
            }

            // Now, you have a list of all loaded scenes in the 'loadedScenes' variable.
            foreach (Scene scene in loadedScenes)
            {
                Debug.Log("Loaded Scene Name: " + scene.name);
            }
        }
    }
}

