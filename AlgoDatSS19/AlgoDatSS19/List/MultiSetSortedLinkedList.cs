namespace AlgoDatSS19
{
    class MultiSetSortedLinkedList : SupportList, ISetSorted
    {
        public override bool Insert(int x)
        {
            AddSorted(x);
            return true;
        }
    }
}
