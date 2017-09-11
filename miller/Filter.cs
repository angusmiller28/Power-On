using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miller
{
    public class Filter
    {
        public string Title { get; set; }
        public string FilterListOptions { get; set; }
        public ArrayList CreateArrayList()
        {
            ArrayList options = new ArrayList();
            // break string and add to array list
            string[] tokens = FilterListOptions.Split(new[] { "+" }, StringSplitOptions.None);

            foreach (string token in tokens)
                options.Add(token);

            return options;
        }
    }
}