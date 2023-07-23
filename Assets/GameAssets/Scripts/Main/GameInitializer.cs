using System;
using System.Linq;
using GameAssets.Scripts.Interfaces;
using UnityEngine;

namespace GameAssets.Scripts.Main
{
    public class GameInitializer : MonoBehaviour
    {
        private void Awake()
        {
            var config = Resources.LoadAll<GameConfig>("");
            config[0].ApplyData();
            IConfigurable[] configurables = FindObjectsOfType<MonoBehaviour>().OfType<IConfigurable>().ToArray();
            foreach (var iConfigurable in configurables)
            {
                iConfigurable.Configurate(config[0]);
            }
        }
    }
}