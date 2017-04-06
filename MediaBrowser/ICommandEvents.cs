namespace MediaBrowser
{
    public interface ICommandEvent
    {
        string TargetID { get; }
        MBCommandType MBtype { get; }
    }
}