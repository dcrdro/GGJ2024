using UnityEngine;

namespace Core
{
  public class JewelsContainer : MonoBehaviour
  {
    public static JewelsContainer Instance;
    
    [SerializeField]
    private GameObject[] _jewels;
    
    public GameObject this[int index]
    {
      get => _jewels[index];
      set => _jewels[index] = value;
    }

    private void Awake() => 
      Instance = this;
  }
}