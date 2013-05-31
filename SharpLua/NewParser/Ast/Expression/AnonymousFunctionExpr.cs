﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLua.Ast.Expression
{
    public class AnonymousFunctionExpr : Expression
    {
        public List<Statement.Statement> Body = null;
        public bool IsVararg = false;
        public List<Variable> Arguments = new List<Variable>();

        public override Expression Simplify()
        {
            for (int i = 0; i < Body.Count; i++)
                Body[i] = Body[i].Simplify();

            if (Refactoring.CanInline(this))
                return Refactoring.InlineFunction(this).Simplify(); // Simplify call here may be redundant

            return this;
        }
    }
}
