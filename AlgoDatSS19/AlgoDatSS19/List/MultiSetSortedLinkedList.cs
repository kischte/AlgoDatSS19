namespace AlgoDatSS19
{
    class MultiSetSortedLinkedList : SupportList, IMultiSet
    {
        public override bool Insert(int x)
        {
            AddSorted(x);
            return true;
        }
    }
}
