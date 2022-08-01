using UnityEngine;
using Services.Analytics.UnityAnalytics;
using System.Collections.Generic;
using static Services.Analytics.AnalyticsManager;

namespace Services.Analytics
{
    internal class AnalyticsManager : MonoBehaviour, IAnalyticsManager
    {
        private IAnalyticsService[] _services;


        private void Awake()
        {
            _services = new IAnalyticsService[]
            {
                new UnityAnalyticsService()
            };
        }

        public void SendMainMenuOpened() =>
            SendEvent("MainMenuOpened");
        public void SendGameOpened() =>
            SendEvent("GameOpened");

        private void SendEvent(string eventName) 
        {
            foreach (IAnalyticsService service in _services)
                service.SendEvent(eventName);
        }
       

        private void SendEvent(string eventName, Dictionary<string, object> eventData)
        {
            foreach (IAnalyticsService service in _services)
                service.SendEvent(eventName,eventData);
        }

        public void SendGameStarted()
        {
            throw new System.NotImplementedException();
        }

        public void SendTransaction(string productId, decimal amount, string currency)
        {
            throw new System.NotImplementedException();
        }

        internal interface IAnalyticsManager
        {
            void SendGameStarted();
            void SendTransaction(string productId, decimal amount, string currency);
        }
    }
}
