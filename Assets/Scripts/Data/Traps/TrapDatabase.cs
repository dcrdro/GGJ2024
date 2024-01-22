using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu]
public class TrapDatabase : ScriptableObject
{
    public TrapData[] traps;

	public TrapData this[TrapType t] => Array.Find(traps, r => r.trapType == t);
}
