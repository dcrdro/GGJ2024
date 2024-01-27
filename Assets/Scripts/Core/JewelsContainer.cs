using System.Collections.Generic;
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

    private void Awake() => 
      Instance = this;

    public void Remove(Jewel jewel) => 
      _jewels.Remove(jewel);

    public void Add(Jewel jewel) => 
      _jewels.Add(jewel);

        private void OnDrawGizmos()
        {
            foreach (var d in _jewels)
            {
                Gizmos.DrawSphere(d.transform.position, 0.5f);
            }
        }
    }
}