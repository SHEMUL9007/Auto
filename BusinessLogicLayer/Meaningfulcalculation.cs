using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Meaningfulcalculation
    {
        public decimal calculate_profit (decimal sellprice,decimal pruchese)
        {
            // the margin only makes sence if the sellprice is not the same as the pruchese price.
            if (sellprice != pruchese)
            {
                decimal margin = pruchese / (sellprice - pruchese);
            }
            return .20m * (sellprice - pruchese);
        }
    }
}
