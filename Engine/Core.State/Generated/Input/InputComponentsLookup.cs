//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class InputComponentsLookup {

    public const int ActorId = 0;
    public const int Coordinate = 1;
    public const int DatabaseEntityId = 2;
    public const int Selection = 3;
    public const int TargetActorId = 4;
    public const int Tick = 5;

    public const int TotalComponents = 6;

    public static readonly string[] componentNames = {
        "ActorId",
        "Coordinate",
        "DatabaseEntityId",
        "Selection",
        "TargetActorId",
        "Tick"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Lockstep.Core.State.Input.ActorIdComponent),
        typeof(Lockstep.Core.State.Input.CoordinateComponent),
        typeof(Lockstep.Core.State.Input.DatabaseEntityIdComponent),
        typeof(Lockstep.Core.State.Input.SelectionComponent),
        typeof(Lockstep.Core.State.Input.TargetActorIdComponent),
        typeof(Lockstep.Core.State.Input.TickComponent)
    };
}
