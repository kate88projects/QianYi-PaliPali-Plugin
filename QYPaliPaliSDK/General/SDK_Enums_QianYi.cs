using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.General
{
    public class SDK_Enums_QianYi
    {
        public enum EnumQY_Currency
        {
            PHP,
            THB,
            VND,
            IDR,
            MYR,
            TWD,
            SGD,
            AUD,
            JPY,
            EUR,
            GBP,
            CAD,
            USD,
            CNY,
        }

        public enum EnumQY_ASNType
        {
            PURCHASE,
            MANUAL,
            INVENTORY_IMPORT,
            SALE_RETURN,
            FIRST_LEG,
            TRANSFER_PLAN,
            TRANSFER_AVAILABLE,
            ASSEMBLY_ORDER,
            RESTORE_ORDER,
        }

        public enum EnumQY_ASNStatus
        {
            NEW,
            DELETED,
            SHIPPING,
            RECEIVING,
            FINISHED,
            CLOSED,
        }

        public enum EnumQY_SOPaymentMethod
        {
            COD,
            PAY_ONLINE,
        }

    }
}
