﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLua.Ast.Expression
{
    public class TableConstructorExpr : Expression
    {
        public List<Expression> EntryList = new List<Expression>();

        public override Expression Simplify()
        {
            for (int i = 0; i < EntryList.Count; i++)
                EntryList[i] = EntryList[i].Simplify();

            return this;
        }
    }
}
