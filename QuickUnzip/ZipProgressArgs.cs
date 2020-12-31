namespace QuickUnzip
{
    public class ZipProgressArgs
    {
        public string Entry { get; set; }
        public int Index { get; set; }
        public ZipProgressArgsType Execution { get; set; }
    }

    public enum ZipProgressArgsType
    {
        CreatingFiles,
        Extracting
    }
}
