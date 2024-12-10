using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrypoint.PROCESSES.Student
{
    public static class TimePeriods
    {
        // For Simulation

        // Real Code For  CUrren Date
        //public static DateTime CurrentDate { get; } = DateTime.Now;




        //Student time frames
        public static DateTime CurrentDate { get; } = new DateTime(2024, 12, 06);
        public static DateTime ApplicationPeriodStart { get; } = new DateTime(2024, 12, 06);
        public static DateTime ApplicationPeriodEnd { get; } = new DateTime(2024, 12, 11);
        public static DateTime PaymentPeriodStart { get; } = new DateTime(2024, 12, 06);
        public static DateTime PaymentPeriodEnd { get; } = new DateTime(2024, 12, 15);
        public static DateTime ExamPeriodEnd { get; } = new DateTime(2024, 12, 21);
        public static DateTime ExamPeriodStart { get; } = new DateTime(2024, 12, 19);

       //ADmin
        
        public static DateTime ApplicationApprovalEnd { get; } = new DateTime(2024, 12, 14);

        public static DateTime PaymentApprovalEnd { get; } = new DateTime(2024, 12, 17);
        public static DateTime AdmissionApprovalEnd { get; } = new DateTime(2024, 12, 30);

    }
}
