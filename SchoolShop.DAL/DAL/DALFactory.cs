using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.Data.DAL
{
    public class DALFactory
    {
        private static DALFactory _instance;
        private DALFactory() { }

        public static DALFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DALFactory();
                }
                return _instance;
            }
        }

        public UsersDAL UsersDAL
        {
            get { return new UsersDAL(); }
        }

        public ProductDAL ProductDAL
        {
            get { return new ProductDAL(); }
        }

        public DialogDAL DialogDAL
        {
            get { return new DialogDAL(); }
        }
    }
}
