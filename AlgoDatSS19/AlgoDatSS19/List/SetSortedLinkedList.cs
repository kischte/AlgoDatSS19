namespace AlgoDatSS19
{
    class SetSortedLinkedList : SupportList, ISetSorted
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
