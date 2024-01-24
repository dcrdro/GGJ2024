using HouseLogic.Entrances;
using UnityEngine;

namespace Core
{
  public class HouseEntrancesContainer : MonoBehaviour
  {
    public static HouseEntrancesContainer Instance;

    [SerializeField]
    private EntranceBase[] _entrances;

    #region Properties

    public EntranceBase[] Entrances => _entrances;

    #endregion
    
    private void Awake() => 
      Instance = this;
  }
}