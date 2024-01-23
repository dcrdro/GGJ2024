using UnityEngine;

namespace Core
{
  public class JewelsContainer : MonoBehaviour
  {
    public static JewelsContainer Instance;
    
    [SerializeField]
    private GameObject[] _jewels;

    #region Properties

    public float Length => _jewels.Length;
    
    public GameObject this[int index]
    {
      get => _jewels[index];
      set => _jewels[index] = value;
    }

    #endregion
    

    private void Awake() => 
      Instance = this;
  }
}