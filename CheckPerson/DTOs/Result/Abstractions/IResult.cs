using CheckPerson.DTOs.Result.Implementations;

namespace CheckPerson.DTOs.Result.Abstractions
{
    public interface IResult
    {
        bool Success { get; }
        ResponseMessage ErrorMessage { get; }
    }
}
