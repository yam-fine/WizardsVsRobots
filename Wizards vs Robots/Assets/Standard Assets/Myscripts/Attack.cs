using UnityEngine;

public abstract class Attack : ScriptableObject
{
    [Range(0.1f, Mathf.Infinity)]
    [SerializeField]
    protected int damageMultiplier = 1;
    [SerializeField]
    protected AudioClip[] sound;
    public AudioClip Sound { get { return sound[UnityEngine.Random.Range(0, sound.Length)]; } }
    [SerializeField]
    protected float reload = 0;
    public float Reload { get { return reload; } }
    [SerializeField]
    protected Sprite icon;
    public Sprite Icon { get { return icon; } }

    public abstract void Init();
    public abstract void TriggerAttack(Transform source);
}