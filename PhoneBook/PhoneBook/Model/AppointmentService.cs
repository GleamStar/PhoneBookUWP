using System;
using System.Threading.Tasks;
using Windows.Foundation;

namespace PhoneBook.Model
{
    public class AppointmentService
    {
        public static async Task AddAppointment(object sender, DateTime time, string subject, string name)
        {
            var appointment = new Windows.ApplicationModel.Appointments.Appointment();
            var timeNow = DateTime.Now;
            var startTime = time.Month >= timeNow.Month ? new DateTime(timeNow.Year, time.Month, time.Day) : new DateTime(timeNow.Year+1, time.Month, time.Day);
            appointment.StartTime = startTime;
            appointment.Subject = subject;
            appointment.Details = $"Congratulate {name} birthday";
            appointment.Reminder = TimeSpan.FromDays(1);
            var rect = new Rect(0, 0, 100, 100);
            await Windows.ApplicationModel.Appointments.AppointmentManager.ShowAddAppointmentAsync(appointment, rect, Windows.UI.Popups.Placement.Default);
        }
    }
}
