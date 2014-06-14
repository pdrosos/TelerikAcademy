using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class OfficeDocument : EncryptableDocumnet
{
    public string Versoin { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "version")
        {
            this.Versoin = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(
        IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("version", this.Versoin));
        base.SaveAllProperties(output);
    }
}