namespace AlgoDatSS19
{
    class MultiSetUnsortedList : SupportList, IMultiSet
    {
        public override bool Insert(int x)
        {
            Enque(x);
            return true;
        }
    }
}
