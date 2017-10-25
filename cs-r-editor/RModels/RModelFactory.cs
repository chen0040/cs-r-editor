using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs_r_editor
{
    public class RModelFactory
    {
        private static RModelFactory mDefault = null;
        private static object mSyncObj = new object();

        public static RModelFactory Default
        {
            get
            {
                if (mDefault == null)
                {
                    lock (mSyncObj)
                    {
                        mDefault = new RModelFactory();
                    }
                }
                return mDefault;
            }
        }

        public List<RModel> CreateModels()
        {
            List<RModel> models = new List<RModel>();

            models.Add(new RModel());

            return models;
        }
    }
}
