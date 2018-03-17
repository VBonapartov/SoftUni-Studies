using System.Collections.Generic;

public interface ILeutenantGeneral : IPrivate
{
    IReadOnlyList<IPrivate> PrivateSoldiers { get; }
}
