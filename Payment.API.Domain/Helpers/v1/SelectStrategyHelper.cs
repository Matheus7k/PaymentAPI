namespace Payment.API.Domain.Helpers.v1
{
    public static class SelectStrategyHelper
    {
        public static object SelectStrategy(this Entities.v1.Payment payment)
        {
            try
            {
                var type = Type.GetType($"Payment.API.Domain.Strategies.v1.{payment.PaymentForm}Strategy", true, true);
                var constructor = type.GetConstructor(Type.EmptyTypes);
                object strategy = constructor.Invoke(new object[] { });

                return strategy;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
