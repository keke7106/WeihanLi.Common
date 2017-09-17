using System;
using System.Collections;
using System.Collections.Generic;

namespace WeihanLi.Common.Models
{
    public class PagedListModel<T> : IEnumerable<T>
    {
        public List<T> Data { get; set; }

        private int pageIndex;

        public int PageIndex
        {
            get => pageIndex;
            set
            {
                if (value > 0)
                {
                    pageIndex = value;
                }
            }
        }

        private int pageSize;

        public int PageSize
        {
            get => pageSize;
            set
            {
                if (value > 0)
                {
                    pageSize = value;
                }
                else
                {
                    PageSize = 10;
                }
            }
        }

        private int totalCount;

        public int TotalCount
        {
            get => totalCount;
            set
            {
                if (value > 0)
                {
                    totalCount = value;
                }
            }
        }

        public int PageCount => Convert.ToInt32(Math.Ceiling(TotalCount * 1.0 / PageSize));

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }
    }
}