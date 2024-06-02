using UnityEngine;
using Random = UnityEngine.Random;

public class Cheer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start() {
        animator.SetTrigger(Animator.StringToHash("Cheer" + Random.Range(1, 3)));   
    }
}