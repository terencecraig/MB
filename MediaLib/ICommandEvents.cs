using MediaLib;

namespace MediaLib
{
    public interface ICommandEvent
    {
        string TargetID { get; }
        MBCommandType MBtype { get; }
    }
}