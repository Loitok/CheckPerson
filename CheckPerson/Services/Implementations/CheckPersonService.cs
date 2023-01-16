using AutoMapper;
using CheckPerson.DTOs.Person;
using CheckPerson.DTOs.Result.Abstractions.Generics;
using CheckPerson.DTOs.Result.Implementations.Generics;
using CheckPerson.Services.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckPerson.Services.Implementations
{
    public class CheckPersonService : ICheckPersonService
    {
        private readonly IMapper _mapper;

        private const string ApiUrl = "https://rickandmortyapi.com/api/";

        public CheckPersonService(IMapper mapper)
            => _mapper = mapper;

        public async Task<IResult<bool>> CheckPersonAsync(CheckPersonDto checkPersonDto)
        {
            try
            {
                using var client = new HttpClient();

                var personResponse =
                    await client.GetAsync(
                        ApiUrl + $"character/?name={ checkPersonDto.PersonName }");

                if (!personResponse.IsSuccessStatusCode)
                    return Result<bool>.CreateFailure("HTTP Response was unsuccessful!");

                var personResponseBody = await personResponse.Content.ReadAsStringAsync();

                var person = JsonConvert.DeserializeObject<ResultDto>(personResponseBody)
                    .Results
                    .FirstOrDefault();

                if (person?.Episode is null)
                    return Result<bool>.CreateFailure("Person/person's episodes not find!");

                var episode = string.Join(',', person.Episode);

                var episodeNumbers = Regex.Matches(episode, @"\d+");

                var episodeResponse =
                    await client.GetAsync(
                        ApiUrl + $"episode/{string.Join(',', episodeNumbers)},");

                if (!episodeResponse.IsSuccessStatusCode)
                    return Result<bool>.CreateFailure("HTTP Response was unsuccessful!");

                var episodeResponseBody = await episodeResponse.Content.ReadAsStringAsync();

                IList<EpisodesDto> episodes = JsonConvert.DeserializeObject<IList<EpisodesDto>>(episodeResponseBody);

                var commons = episodes.Any(x => x.Name == checkPersonDto.EpisodeName);

                return Result<bool>.CreateSuccess(commons);
            }
            catch (Exception e)
            {
                return Result<bool>.CreateFailure(e.Message);
            }
        }


        public async Task<IResult<GetPersonDto>> GetPersonAsync(string name)
        {
            try
            {
                using var client = new HttpClient();

                var personResponse =
                    await client.GetAsync(
                        ApiUrl + $"character/?name={ name }");

                if (!personResponse.IsSuccessStatusCode)
                    return Result<GetPersonDto>.CreateFailure("HTTP Response was unsuccessful!");

                var personResponseBody = await personResponse.Content.ReadAsStringAsync();

                var person = JsonConvert.DeserializeObject<GetResultDto>(personResponseBody)
                    .Results
                    .FirstOrDefault();

                if (person is null)
                    return Result<GetPersonDto>.CreateFailure("Person not find!");

                var personInfo = _mapper.Map<GetPersonDto>(person);

                if (string.IsNullOrEmpty(person.Origin.Url))
                    return Result<GetPersonDto>.CreateSuccess(personInfo);

                var originResponse =
                    await client.GetAsync(person.Origin.Url);

                if (!originResponse.IsSuccessStatusCode)
                    return Result<GetPersonDto>.CreateFailure("HTTP Response was unsuccessful!");

                var originResponseBody = await originResponse.Content.ReadAsStringAsync();

                var origin = JsonConvert.DeserializeObject<GetPersonOriginDto>(originResponseBody);
                
                personInfo.Origin = _mapper.Map<GetPersonOriginDto>(origin);

                return Result<GetPersonDto>.CreateSuccess(personInfo);
            }
            catch (Exception e)
            {
                return Result<GetPersonDto>.CreateFailure(e.Message);
            }
        }
    }
}
