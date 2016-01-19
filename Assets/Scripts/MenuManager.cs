using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MenuManager : MonoBehaviour
    {
        private AsyncOperation _asyncOperation;

        public void StartGame()
        {
            StartCoroutine(this.LoadLevel());
        }

        private IEnumerator LoadLevel()
        {
            this._asyncOperation = Application.LoadLevelAsync("MainScene");
            while (!this._asyncOperation.isDone)
            {
                yield return null;
            }
        }
    }
}
