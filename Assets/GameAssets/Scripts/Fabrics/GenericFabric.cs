using UnityEngine;

namespace GameAssets.Scripts.Fabrics
{
    public class GenericFabric<TPrefabType> : MonoBehaviour where TPrefabType : MonoBehaviour 
    {
        [SerializeField] private protected TPrefabType prefab;

        public virtual TPrefabType GetObject<TFabricConfig>(TFabricConfig config,Vector3 pos) where TFabricConfig : FabricConfig
        {
            return null;
        }
    }

    public class FabricConfig
    {
        
    }
}