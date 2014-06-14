using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class EncryptableDocumnet : BinaryDocumnet, IEncryptable
{
    public bool IsEncrypted { get; private set; }

    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }
    public override string ToString()
    {
        if (IsEncrypted)
        {
            return this.GetType().Name + "[encrypted]";
        }
        else
        {
            return base.ToString();
        }
    }
}
