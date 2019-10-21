namespace DataStructs
{
    public interface IQHeap
    {
        int[] getSortedHeapEntries();
        int WhereIsHeapNotValid();

        bool isHeapValid();
        int Get(int n);

        int Peek { get; }
        int Size { get; }

        int Pop();
        void Push(int x);

        int Find(int x);

        void RemoveAt(int x);
    }
}
