
#region Usings
using System;
using System.Collections.Generic;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public interface iLocalUpdate {

        void initializeLocalUpdate();

        iComponent getInterest();

        List<iComponent> getInterests();

        void onLocalUpdate();

    }

}