using System.Collections.Generic;

namespace CheckPerson.DTOs.Person
{
    public class ResultDto
    {
        public IReadOnlyCollection<GetPersonResultDto> Results { get; set; }
    }

    public class GetPersonResultDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<string> Episode { get; set; }
    }

    public class EpisodesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    
}
