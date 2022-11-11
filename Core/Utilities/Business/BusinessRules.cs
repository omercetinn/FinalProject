using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //bütün kuralları gezip kurala uymayan varsa döndürdür
        public static IResult Run(params IResult[] logics) //params ile tüm metodları yan yana yazabiliriz araya virgül koyarak
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
