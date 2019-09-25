using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BST : Access_Common
    {
        private string BST = KeyConst.CanMsgId.BST;
        public void GetBST(DbService db)
        {
            this._Data = db.QueryConsistMsg(BST);
        }
    }
}
