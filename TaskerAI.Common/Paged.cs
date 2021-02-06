namespace TaskerAI.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Paged<T>
    {
        public static Paged<T> CreatePagedObject(IEnumerable<T> items, int pageIndex, int pageSize, int itemCount, int indexFrom = 0) => new Paged<T>(items, pageIndex, pageSize, itemCount, indexFrom);

        private Paged(IEnumerable<T> items, int pageIndex, int pageSize, int itemCount, int indexFrom = 0)
        {
            if (indexFrom > pageIndex)
            {
                throw new ArgumentException($"indexFrom: {indexFrom} > pageIndex: {pageIndex}, must indexFrom <= pageIndex");
            }

            this.PageIndex = pageIndex;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = itemCount;
            this.Items = items.ToList();
        }

        public IReadOnlyCollection<T> Items { get; private set; }
        public int IndexFrom { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages => this.PageSize != 0 ? (int)Math.Ceiling(this.TotalCount / (double)this.PageSize) : 0;
        public bool HasPreviousPage => this.PageIndex - this.IndexFrom > 0;
        public bool HasNextPage => this.PageIndex - this.IndexFrom + 1 < this.TotalPages;

        public Paged<Tout> Adapt<Tout>(IMapper<T, Tout> mapper) => new Paged<Tout>(mapper.Map(this.Items), this.PageIndex, this.PageSize, this.TotalCount, this.IndexFrom);
    }
}