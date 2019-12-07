﻿using System.Collections.Generic;

namespace TextFileAnalyzer.Models
{
    public class Row
    {
        public IList<string> Cells { get; private set; } = new List<string>();

        public void AddContent(string[] content)
        {
            Cells = content;
        }
    }
}
