using VFS;

namespace VFS
{
    public interface ICommandEvent
    {
        string TargetID { get; }
        MBCommandType MBtype { get; }
    }
}