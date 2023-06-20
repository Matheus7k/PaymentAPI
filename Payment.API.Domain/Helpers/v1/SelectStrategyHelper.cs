namespace Payment.API.Domain.Helpers.v1
{
    public static class SelectStrategyHelper
    {
        public static object SelectStrategy(this Entities.v1.Payment payment)
        {
            try
            {
                /*
                var list = AppDomain.CurrentDomain.GetAssemblies().SelectMany(t => t.GetTypes()).Where(t => t.IsClass && t.Namespace == "Payment.API.Domain.Strategies.v1");
                var type = list.FirstOrDefault(t => t.Name == payment.PaymentForm);
                */

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
