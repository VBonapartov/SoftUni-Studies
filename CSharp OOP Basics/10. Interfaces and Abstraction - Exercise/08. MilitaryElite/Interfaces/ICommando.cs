using System.Collections.Generic;

public interface ICommando : ISpecialisedSoldier
{
    IReadOnlyList<IMission> Missions { get; }
}
