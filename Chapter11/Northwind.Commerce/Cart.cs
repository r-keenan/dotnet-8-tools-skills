namespace Northwind.Commerce
{
    public class Cart
    {
        private readonly Store _store;

        public Cart(Store store)
        {
            _store = store;
        }

        // Key is ProductId, Value is Quantity
        public Dictionary<int, int> Items { get; } = new();

        public void AddItems(int productId, int quantity)
        {
            if (Items.ContainsKey(productId))
                Items[productId] += quantity;
            else
                Items.Add(productId, quantity);
        }

        public void RemoveItems(int productId, int quantity)
        {
            Items[productId] -= quantity;
        }

        public bool Checkout()
        {
            foreach (var item in Items)
            {
                if (!_store.RemoveInventory(item.Key, item.Value))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
