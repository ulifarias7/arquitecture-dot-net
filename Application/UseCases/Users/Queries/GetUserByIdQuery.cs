using Application.Common.Models;
using Application.Ports.Primary;
using MediatR;

namespace Application.UseCases.Users.Queries
{
    public class GetUserByIdQuery : IRequest<ResponseObjectJson>
    {
        public int UserId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResponseObjectJson>
    {
        private readonly IUserService _userServices;

        public GetUserByIdQueryHandler(IUserService userServices)
        {
            _userServices = userServices;
        }

        public async Task<ResponseObjectJson> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userServices.GetUserById(request.UserId);

            if (user == null)
            {
                return new ResponseObjectJson
                {
                    Code = 404,
                    Message = "User not found",
                    Responses = null
                };
            }

            return new ResponseObjectJson
            {
                Code = 200,
                Message = "User retrieved successfully",
                Responses = user
            };
        }
    }
}
