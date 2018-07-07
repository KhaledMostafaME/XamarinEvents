using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace XamarinEvents.Service
{
    public class PushMsg   
    {
        public void sendToast(string message, int duration, Color color)
        {
            var toastConfig = new ToastConfig(message);
            toastConfig.SetDuration(duration);
            toastConfig.SetBackgroundColor(color);

            UserDialogs.Instance.Toast(toastConfig);
        }
     
    }
}
