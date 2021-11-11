﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Common
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}