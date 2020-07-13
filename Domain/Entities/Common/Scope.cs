using System.Text.Json.Serialization;

namespace Domain.Entities.Common
{
    //TODO: need to make auto getting from the authDB
    public class Scope
    {
        [JsonIgnore] public int ScopeId { get; set; }
        [JsonIgnore] public int ExternalId { get; set; }

        public string ScopeName { get; set; }

        [JsonIgnore] public int AuthenticationOptionId { get; set; }
    }
}