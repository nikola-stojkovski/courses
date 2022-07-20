namespace Courses.Core.Contracts.Models.Common
{
    using System;
    using System.Text.Json.Serialization;

    public abstract class RestBase
    {
        [JsonIgnore]
        public int Id { get; set; }

        public Guid Uid { get; set; }
    }
}
