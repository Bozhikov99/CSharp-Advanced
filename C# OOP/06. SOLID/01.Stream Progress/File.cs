namespace P01.Stream_Progress
{
    public class File :IProgressible
    {
        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
