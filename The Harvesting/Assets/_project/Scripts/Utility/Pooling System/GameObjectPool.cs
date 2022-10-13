using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// Scriptable Object Object Pooling system. Use objects that extend Poolable.
    /// </summary>
    [CreateAssetMenu(fileName = "New GameObject Pool", menuName = "Pooling/GameObject Pooling")]
    public class GameObjectPool : ScriptableObject
    {
        public Poolable prefab;
        public bool HideInactiveInHierarchy = false;
        public bool HideActiveInHierarchy = false;
        private Stack<Poolable> readyObjects = new Stack<Poolable>();
        private Queue<Poolable> objectsInUse = new Queue<Poolable>();
        private bool initialized;
        [Header("DON'T EDIT DURING RUNTIME")]
        [SerializeField]
        private int MAX_SIZE = 12;

        /// <summary>
        /// Inilialize the Game Object Pool by instantiating Poolable objects.
        /// </summary>
        public void Init()
        {
            if (initialized)
            {
                return;
            }

            if (prefab != null)
            {
                for (int i = 0; i < MAX_SIZE; i++)
                {
                    var spawn = Instantiate(prefab);
                    spawn.Init(this);
                    if (HideInactiveInHierarchy) spawn.gameObject.hideFlags = HideFlags.HideInHierarchy;
                    spawn.gameObject.SetActive(false);
                    readyObjects.Push(spawn);
                    if (i == MAX_SIZE - 1) initialized = true;
                }

            }

        }
        public void OnEnable()
        {
            initialized = false;
        }

        /// <summary>
        /// Returns an object from the pool to be used.
        /// </summary>
        /// <returns></returns>
        public Poolable SpawnObject()
        {
            if (readyObjects.Count == 0)
            {
                return null;
            }
            var spawn = readyObjects.Pop();

            if (spawn != null)
            {
                spawn.gameObject.SetActive(true);
                if (!HideActiveInHierarchy) spawn.gameObject.hideFlags = HideFlags.None;
                objectsInUse.Enqueue(spawn);
                return spawn;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the released Poolable object back to the pool.
        /// </summary>
        /// <param name="itemToReturn"></param>
        public void ReturnObject(Poolable itemToReturn)
        {
            if (objectsInUse.Count > 0)
            {
                objectsInUse.Dequeue();
            }

            if (HideInactiveInHierarchy)
            {
                itemToReturn.gameObject.hideFlags = HideFlags.HideInHierarchy;
            }

            readyObjects.Push(itemToReturn);
        }
    }
}