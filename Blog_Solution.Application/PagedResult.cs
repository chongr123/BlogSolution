using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog_Solution
{
    /// <summary>
    /// 分页查询实现类
    /// </summary>
    /// <typeparam name="T">T对象为实体对象的继承类</typeparam>
    [Serializable]
    public class PagedResult<T> : IPagedResult<T> where T : Entity
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        public PagedResult(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int total = source.Count();
            this.TotalCount = total;
            this.Items = source.Skip(pageIndex).Take(pageSize).ToList();
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>

        public PagedResult(IList<T> source, int pageIndex, int pageSize)
        {
            int total = source.Count();
            this.TotalCount = total;
            this.Items = source.Skip(pageIndex).Take(pageSize).ToList();
        }
        /// <summary>
        /// 数据集
        /// </summary>
        public IReadOnlyList<T> Items { get; set; }

        /// <summary>
        /// 总个数
        /// </summary>
        public int TotalCount { get; set; }
    }
}
