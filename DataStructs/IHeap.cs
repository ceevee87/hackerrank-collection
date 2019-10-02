namespace DataStructs
{
    public interface IHeap
    {
        int Peek { get; }
        int Size { get; }

        int Pop();
        void Push(int x);

        void print();
    }
}
