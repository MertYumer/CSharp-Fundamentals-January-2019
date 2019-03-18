namespace P01_StreamProgressInfo
{
    public interface IStreamable
    {
        int Length { get; }

        int BytesSent { get; }
    }
}
