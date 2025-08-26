using UnityEngine;

public class MovmentHendel : MonoBehaviour
{
    [SerializeField] private Patruller _patruller;
    [SerializeField] private Folower _folower;

    private Coroutine _patruleCoroutine;

    public Folower Folower => _folower;

    private void Start()
    {
        _patruleCoroutine = StartCoroutine(_patruller.MoveLoop());
    }

    public void StartFolowing(Character character)
    {
        StopCoroutine(_patruleCoroutine);

        StartCoroutine(_folower.Folow(character.GetCurrentPosition()));
    }
}