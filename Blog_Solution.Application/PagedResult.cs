using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog_Solution
{
    [Serializable]
    public class PagedResult<T> : IPagedResult<T> where T : Entity
    {
        public PagedResult(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int total = source.Count();
            this.TotalCount = total;
            this.Items = source.Skip(pageIndex).Take(pageSize).ToList();
        }


        public PagedResult(IList<T> source, int pageIndex, int pageSize)
        {
            int total = source.Count();
            this.TotalCount = total;
            this.Items = source.Skip(pageIndex).Take(pageSize).ToList();
        }
        public IReadOnlyList<T> Items { get; set; }

        public int TotalCount { get; set; }
    }
}
