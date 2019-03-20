﻿using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

namespace JSONPlaceholderSample.Helpers
{
    public static class ConnectivityHelper
    {
        public const string TimeOutErrorMessage = "Timeout expired";
        public const string SomethingWentWrong = "Something went wrong";
        public const string ConnectionErrorMessage = "There is no access to the Internet. Check the connection";

        private const string IsConnected = "IsConnected";

        public static void InitConnectionStatus()
        {
            if (!CrossConnectivity.IsSupported)
            {
                SetConnectionStatus(true);
            }
            SetConnectionStatus(CrossConnectivity.Current.IsConnected);
            CrossConnectivity.Current.ConnectivityChanged += CurrentOnConnectivityChanged;
        }

        public static void CurrentOnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            SetConnectionStatus(e.IsConnected);
        }

        public static bool GetConnectionStatus()
        {
            return !CrossConnectivity.IsSupported || CrossConnectivity.Current.IsConnected;
        }

        private static void SetConnectionStatus(bool connectivityStatus)
        {
            if (!connectivityStatus)
            {
                if (Application.Current.Properties.ContainsKey(IsConnected))
                {
                    Application.Current.Properties.Remove(IsConnected);
                }
            }
            else
            {
                if (!Application.Current.Properties.ContainsKey(IsConnected))
                {
                    Application.Current.Properties.Add(IsConnected, true);
                }
            }
        }
    }
}