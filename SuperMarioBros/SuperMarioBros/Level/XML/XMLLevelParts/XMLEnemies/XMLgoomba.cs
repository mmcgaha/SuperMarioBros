﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    public class XMLgoomba : IXMLLevelObject
    {
        int x;
        int y;
        int count;

        public XMLgoomba(XMLTree tree)
        {
            this.x = int.Parse(tree.Attribute("x"));
            this.y = int.Parse(tree.Attribute("y"));
            String c = tree.Attribute("count");
            this.count = c == null ? 1 : int.Parse(c);
        }

        public void ProcessObject(List<List<Object>> matrix)
        {
            for (int i = 0; i < count; i++)
            {
                matrix[x+i].Add(new Goomba(16 * x + 24 * i, 16 * y));
            }
        }
    }
}
