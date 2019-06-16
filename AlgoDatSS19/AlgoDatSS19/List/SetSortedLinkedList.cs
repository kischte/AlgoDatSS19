namespace AlgoDatSS19
{
    class SetSortedLinkedList : MultiSetSortedLinkedList, ISetSorted
    {
        public override bool Insert(int x)
        {
            if (!Search(x))
            {
                AddSorted(x);
                return true;
            }
            return false;
        }
    }
}
