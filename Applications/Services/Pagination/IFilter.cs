using System;

namespace Application.Services.Pagination
{
    public interface IFilter : ICloneable
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
