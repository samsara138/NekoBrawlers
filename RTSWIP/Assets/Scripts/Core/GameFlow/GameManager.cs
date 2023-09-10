using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.GameFlow
{
    public enum GameState
    {
        InitState = 0
    }

    public enum GameScene
    {
        MainMenu = 0
    }

    public sealed class GameManager : MonoBehaviour
    {
        #region Singleton behaviour

        private static GameManager instance;
        public static GameManager Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        #endregion

        private GameState State;

        public void UpdateGameState(GameState newState)
        {
            Log("Change State: " + newState);
            instance.State = newState;
            switch (newState)
            {
                case GameState.InitState:
                    break;
            }
        }

        private void Log(string msg)
        {
            if (GlobalParameters.GAME_MANAGER_DEBUG_ECHO)
                Debug.Log("<b><color=#00FFFF>GameManager</color></b> " + msg);
        }
    }
}