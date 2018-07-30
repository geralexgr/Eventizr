using eventizr.Models;
using System;
using System.Collections.Generic;

namespace eventizr.Helpers
{
    public class ModelHelper
    {


        public SqlitePage FbPageToSQLite(Models.Page page)
        {
            try
            {
                SqlitePage _sqlitempage = new SqlitePage();
                _sqlitempage.Address = page.Address;
                _sqlitempage.Category = page.Category;
                _sqlitempage.Id = page.Id;
                _sqlitempage.Name = page.Name;
                _sqlitempage.Url = page.Url;
                if (string.IsNullOrEmpty(page.Picture.Data.Url)) _sqlitempage.Picture = "";
                else _sqlitempage.Picture = page.Picture.Data.Url;
                _sqlitempage.Description = page.Description;
                return _sqlitempage;
            }
            catch (Exception)
            {
                return new SqlitePage();
            }
                         
        }


        public SqliteEvent FbEventToSQLite(Models.Event.FbData data)
        {
            try
            {
                SqliteEvent tempEvent = new SqliteEvent();
                tempEvent.Description = data.Description;
                tempEvent.Longitude = data.Location.Info.Longitude;
                tempEvent.Latitude = data.Location.Info.Latitude;
                tempEvent.Name = data.Name;
                tempEvent.Picture = data.Cover.Source;
                tempEvent.Time = data.Time;
                tempEvent.Host = data.Host.Name;
                if (string.IsNullOrEmpty(data.Location.Info.Street) ) tempEvent.Address = data.Location.Info.City;
                else if (!string.IsNullOrEmpty(data.Location.Info.Street)) tempEvent.Address = data.Location.Info.Street + " @" + data.Location.Info.City;
                else if (string.IsNullOrEmpty(data.Location.Info.Street) && string.IsNullOrEmpty(data.Location.Info.City)) tempEvent.Address = "Unknown";

                    return tempEvent;
            }
            catch (Exception) 
            {
                return new SqliteEvent();
            }
        }


    }
}
