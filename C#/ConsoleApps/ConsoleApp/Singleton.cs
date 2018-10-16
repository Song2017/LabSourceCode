namespace ConsoleApp
{
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        private Singleton() { }
        static Singleton() { } // Make sure it's truly lazy
        public static Singleton Instance { get { return instance; } }
    }
}