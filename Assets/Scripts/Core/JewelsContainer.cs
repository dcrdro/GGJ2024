using System.Collections.Generic;
using System.Linq;
using JewelLogic;
using UnityEngine;

namespace Core
{
  public class JewelsContainer : MonoBehaviour
  {
    public static JewelsContainer Instance;
    
    [SerializeField]
    private List<Jewel> _jewels;

    #region Properties

    public int Length => _jewels.Count;
    
    public Jewel this[int index]
    {
      get => _jewels[index];
      set => _jewels[index] = value;
    }

        #endregion

        private void Awake()
        {
            _jewels = GetComponentsInChildren<Jewel>().ToList();
            Instance = this;
        }

        public void Remove(Jewel jewel) => 
      _jewels.Remove(jewel);

    public void Add(Jewel jewel) => 
      _jewels.Add(jewel);

    }
}