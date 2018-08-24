using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Android.Util;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace QAiku.Droid
{
    public static class QaikuExtensions
    {
        /// <summary>
        /// Turns an IEnumerable collection into an ObservableCollection in the same type
        /// </summary>
        /// <typeparam name="T">Type of List and ObservableCollection</typeparam>
        /// <param name="enumerablelist">The list to be converted</param>
        /// <returns>ObservableCollection<T></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerablelist)
        {
            Log.Info("QTDebug", "Extensions.ToObservableCollection käynnistyi");

            if (enumerablelist != null)
            {
                var observableCollection = new ObservableCollection<T>();
                foreach (var item in enumerablelist)
                {
                    observableCollection.Add(item);
                }
            Log.Info("QTDebug", "Extensions.ToObservableCollection valmistui");
                return observableCollection;
            }
            Log.Info("QTDebug", "Extensions.ToObservableCollection nullasi");

            return null;
        }
    }
}