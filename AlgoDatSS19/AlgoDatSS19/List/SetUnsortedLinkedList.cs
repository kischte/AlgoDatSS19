namespace AlgoDatSS19
{
    class SetUnsortedLinkedList : MultiSetUnsortedLinkedList, ISet
    {
        public override bool Insert(int x)
        {
            if (!Search(x))   //wenn Element nicht gefunden
            {
                Enque(x);     //am Ende der Liste einreihen
                return true;
            }
            return false;     //Element schon vorhanden, nicht speichern
        }
    }
}
