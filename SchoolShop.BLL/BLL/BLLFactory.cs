using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Business.BLL
{
    public class BLLFactory
    {
        private static BLLFactory _instance;
        private BLLFactory()
        {

        }
        public static BLLFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BLLFactory();
                }
                return _instance;
            }
           
        }

        public UsersBLL UsersBLL
        {
            get { return new UsersBLL(); }
        }

        public ProductBLL ProductBLL
        {
            get { return new ProductBLL(); }
        }

        public DialogBLL DialogBLL
        {
            get { return new DialogBLL(); }
        }
    }
}
