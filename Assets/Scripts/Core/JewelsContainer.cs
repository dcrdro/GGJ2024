using JewelLogic;
using UnityEngine;

namespace Core
{
  public class JewelsContainer : MonoBehaviour
  {
    public static JewelsContainer Instance;
    
    [SerializeField]
    private Jewel[] _jewels;

    #region Properties

    public float Length => _jewels.Length;
    
    public Jewel this[int index]
    {
      get => _jewels[index];
      set => _jewels[index] = value;
    }

    #endregion

    private void Awake() => 
      Instance = this;
  }
}