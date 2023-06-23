using AutoMapper;

namespace Payment.API.Domain.Queries.Payment.v1.List
{
    public class ListPaymentQueryProfile : Profile
    {
        public ListPaymentQueryProfile()
        {
            CreateMap<Entities.v1.Payment, ListPaymentQueryResponse>()
                .ForMember(fieldOutput => fieldOutput.Cpf, option => option
                    .MapFrom(input => input.Cpf))
                .ForMember(fieldOutput => fieldOutput.PaymentForm, option => option
                    .MapFrom(input => input.PaymentForm))
                .ForMember(fieldOutput => fieldOutput.Price, option => option
                    .MapFrom(input => input.Price));
        }
    }
}
