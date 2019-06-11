namespace AlgoDatSS19
{
    class MultiSetUnsortedLinkedList : SupportList, IMultiSet
    {
        public override bool Insert(int x)
        {
            Enque(x);
            return true;
        }
    }
}
