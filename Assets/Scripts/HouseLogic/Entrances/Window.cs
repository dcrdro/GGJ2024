using UnityEngine;

namespace HouseLogic.Entrances
{
  public class Window : EntranceBase
  {
    [SerializeField]
    private Transform _insidePoint;

    #region Properties

    public Transform InsidePoint => _insidePoint;

    #endregion
  }
}