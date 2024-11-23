using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace entrypoint.PROCESSES.Student_application
{
    public class StudentChangeIconColor
    {
        public void UpdateButtonImages(PictureBox picIconApplication, PictureBox picIconAdmission,
       PictureBox picIconPay, PictureBox picIconExamination, string iconAppList, string iconAdmission,
       string iconPayment, string iconExams)
        {
            // Location of bin/debug
            string startupPath = Application.StartupPath;
            string projectRootPath = Path.GetFullPath(Path.Combine(startupPath, @"..\..\.."));

            // Update images based on the passed parameters
            picIconApplication.Image = Image.FromFile(Path.Combine(projectRootPath, "Images", iconAppList));
            picIconAdmission.Image = Image.FromFile(Path.Combine(projectRootPath, "Images", iconAdmission));
            picIconPay.Image = Image.FromFile(Path.Combine(projectRootPath, "Images", iconPayment));
            picIconExamination.Image = Image.FromFile(Path.Combine(projectRootPath, "Images", iconExams));
        }

    }
}
