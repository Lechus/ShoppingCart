namespace Supermarket.Checkout.Services
{
    using Supermarket.Checkout.Models;

    public interface IOrderCalculationsService
    {
        decimal GetTotalPrice(OrderItem orderItem);
    }
}