﻿

        public Task<T> ReviewByPagination<T>(string term, string orderBy, int currentPage, string token)
            //string apiUrl = $"{carUrl}/api/v1/StateAPI/GetStatesData/{Id}/{search}/{pageSize}/{pageNumber}";
            string apiUrl = $"{categoryUrl}/api/v1/ReviewAPI/ReviewByPagination?term={term}&orderBy={orderBy}&currentPage={currentPage}";