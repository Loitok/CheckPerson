using CheckPerson.DTOs.Person;
using CheckPerson.DTOs.Result.Abstractions.Generics;
using System.Threading.Tasks;

namespace CheckPerson.Services.Abstractions
{
    public interface ICheckPersonService
    {
        Task<IResult<bool>> CheckPersonAsync(CheckPersonDto checkPersonDto);
        Task<IResult<GetPersonDto>> GetPersonAsync(string name);
    }
}
