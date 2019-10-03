
#region Usings
using System;
using System.Windows.Forms;
#endregion

namespace RemoteCtrl {

    public class Validation {

        public static void show() {
            MessageBox.Show("Some input values are invalid.", "Invalid Input Fields", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Exclamation, 
                            MessageBoxDefaultButton.Button1);
        }

        public static void show(int min, int max) {
            MessageBox.Show("Please enter a value between "+min+" and "+max+".", "Value Out Of Range", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Exclamation, 
                            MessageBoxDefaultButton.Button1);
        }

        public static bool validate(string text, int maxLength) {
            if(text.Length>maxLength) {
                MessageBox.Show("Please only enter values with a maximal length of "+maxLength+".", "Text Too Long", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Exclamation, 
                                MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        public static bool validate(int value, int min, int max) {
            if(value<min || value>max) {
                MessageBox.Show("Please enter a value between "+min+" and "+max+".", "Value Out Of Range", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Exclamation, 
                                MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        

    }

}
