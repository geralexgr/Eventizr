using System;
using System.Collections.Generic;
using System.Text;
using Realms;
using eventizr.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace eventizr.Services
{
    public class RealmService
    {
        Realm realm;
        Transaction transaction;

        public RealmService()
        {
            realm = Realm.GetInstance();
        }


        public void AddPage(RealmPage page)
        {

            transaction = realm.BeginWrite();
            var entry = realm.Add(page);
            transaction.Commit();
        }
        public bool CheckPageExists(RealmPage page)
        {
            try
            {
                var result = realm.All<RealmPage>().Where(x => x.Id == page.Id).First();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ObservableCollection<RealmPage> GetPages()
        {
            var entries =  realm.All<RealmPage>();
            return new ObservableCollection<RealmPage>(entries);
        }

        public void DeletePage(string id)
        {
            transaction = realm.BeginWrite();
            var page = realm.All<RealmPage>().Where(x => x.Id == id).First();
            realm.Remove(page);
            transaction.Commit();
        }
    }
}
