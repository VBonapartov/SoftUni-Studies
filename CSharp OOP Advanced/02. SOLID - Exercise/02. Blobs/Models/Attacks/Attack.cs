using System;

public abstract class Attack : IAttack
{
    private IBlob blob;

    protected Attack(IBlob blob)
    {
        this.Blob = blob;
    }

    public virtual int Damage => this.Blob.Damage;

    protected IBlob Blob
    {
        get
        {
            return this.blob;
        }

        private set
        {
            this.blob = value ?? throw new ArgumentNullException(nameof(value), "A blob cannot be null when creating an attack.");
        }
    }

    public virtual void ActivateEffects()
    {
    }
}
