
#region Usings
using System;
#endregion

namespace CommonCtrl {

    public interface iComponent {

        void open();
        void close();
        void update(Component component);
        void attach(Arduino arduino);

    }

}
