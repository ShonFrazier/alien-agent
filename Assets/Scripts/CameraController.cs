using System;
using UnityEngine;
using UEVec2 = UnityEngine.Vector2;

public class Utility
{
  public class Vector2 {
    public static UEVec2 MinValue { get { return new UEVec2(float.MinValue, float.MinValue); } }
    public static UEVec2 MaxValue { get { return new UEVec2(float.MaxValue, float.MaxValue); } }
  }
  public static UEVec2 Clamp(UEVec2 value, UEVec2 min, UEVec2 max)
  {
    var x = Math.Clamp(value.x, min.x, max.x);
    var y = Math.Clamp(value.y, min.y, max.y);
    return new UEVec2(x, y);
  }
}

public class CameraController : MonoBehaviour
{
  [SerializeField] private Transform player;

  [SerializeField] private Vector2 minimum;
  [SerializeField] private Vector2 maximum;

  private void Start()
  {
    if (minimum == null)
    {
      minimum = Utility.Vector2.MinValue;
    }

    if (maximum == null)
    {
      maximum = Utility.Vector2.MaxValue;
    }
  }

  private void Update()
  {
    var x = Math.Clamp(player.position.x, minimum.x, maximum.x);
    var y = Math.Clamp(player.position.y, minimum.y, maximum.y);
    transform.position = new Vector3(x, y, transform.position.z);
  }
}
