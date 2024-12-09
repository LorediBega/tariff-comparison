using System.Runtime.Serialization;

namespace TariffComparision.API.Models.Exceptions
{
    public class ConsumptionValidationException : Exception
    {
        protected ConsumptionValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        public ConsumptionValidationException()
        {
        }

        public ConsumptionValidationException(string message)
            : base(message)
        {
        }

        public ConsumptionValidationException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
