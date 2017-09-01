﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.UI.Process;

namespace ASF.UI.Process
{
    public class CategoryProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Category/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void insertCategory(Category category)
        {
            ProcessComponent.HttpPost<Category>("rest/Category/Add", category, MediaType.Json);
        }

        public Category findCategory(int id)
        {

            var response = HttpGet<FindResponse>("rest/Category/Find/{id}", MediaType.Json);
            return response.Result;

        }

        public void editCategory(Category category)
        {
            ProcessComponent.HttpPost<Category>("rest/Category/Edit", category, MediaType.Json);
        }

        public void deleteCategory(Category category)
        {
            ProcessComponent.HttpPost<Category>("rest/Category/Remove", category, MediaType.Json);
        }
    }
}