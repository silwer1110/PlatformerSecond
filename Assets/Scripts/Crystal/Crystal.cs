using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Crystal : MonoBehaviour
{
    private int _crystalPoints = 1;

    public event UnityAction<Crystal> Deactivated;

    public void Deactivate()
    {
        Deactivated?.Invoke(this);
    }

    public int GetPoints()
    {
        return _crystalPoints;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}