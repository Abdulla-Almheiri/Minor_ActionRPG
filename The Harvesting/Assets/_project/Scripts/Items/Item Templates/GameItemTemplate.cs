using UnityEngine;

namespace Harvesting
{
    //[CreateAssetMenu(fileName = "new item template", menuName = "Data/Items/Item Template")]
    public abstract class GameItemTemplate<T> : ScriptableObject, IGameItemTemplate<T> where T : GameItem
    {
        public Sprite Icon { get; protected set; }
        public string Name { get; protected set; }

        public int Price { get; protected set;}

        public ItemQuality Quality { get; protected set; }

        public abstract T Generate(int level, int requiredLevel);
      
    }


}
