using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Profile.Analytic
{
    public interface IAnalyticTools
    {
        void SendMessage(string alias, IDictionary<string, object> eventData = null);
    }
}