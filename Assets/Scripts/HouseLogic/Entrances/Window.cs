using UnityEngine;

namespace HouseLogic.Entrances
{
  public class Window : EntranceBase
  {
    [SerializeField]
    private Transform _enteringPoint;

    #region Properties

    public Transform EnteringPoint => _enteringPoint;

    #endregion
  }
}