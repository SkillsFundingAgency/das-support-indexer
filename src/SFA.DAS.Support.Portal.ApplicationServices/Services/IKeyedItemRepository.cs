namespace SFA.DAS.Support.Portal.ApplicationServices.Services
{
    public interface IKeyedItemRepository<in TKey, TItem>
    {
        TItem Store(TItem item);

        TItem Retreive(TKey key);

        void Remove(TKey key);
        
    }
}