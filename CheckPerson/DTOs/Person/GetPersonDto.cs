using System.Collections.Generic;

namespace CheckPerson.DTOs.Person
{
    public class GetResultDto
    {
        public IReadOnlyCollection<GetPersonWithLinkDto> Results { get; set; }
    }

    public class GetPersonBaseDto
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
    }


    public class GetPersonWithLinkDto : GetPersonBaseDto
    {
        public GetPersonOriginWithLinkDto Origin { get; set; }
    }

    public class GetPersonOriginWithLinkDto
    {
        public string Url { get; set; }
    }



    public class GetPersonDto : GetPersonBaseDto
    {
        public GetPersonOriginDto Origin { get; set; }
    }

    public class GetPersonOriginDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Dimension { get; set; }
    }
}
