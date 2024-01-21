using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu]
public class ResourcesDatabase : ScriptableObject
{
    public ResourceData[] resources;

	public ResourceData this[ResourceType t] => Array.Find(resources, r => r.resourceType == t);
}
